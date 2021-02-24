using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.DifferentPlacesXml.PayCard;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
using BenDing.Domain.Models.Params;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.SystemManage;
using BenDing.Domain.Models.Params.UI.DifferentPlaces;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Xml;
using BenDing.Repository.EntityMap;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces;
using Newtonsoft.Json;

namespace BenDing.Service.Providers
{
   public class YdMedicalInsuranceService: IYdMedicalInsuranceService
    {
        private readonly IWebServiceBasicService _serviceBasicService;
        private readonly IWebBasicRepository _webBasicRepository;
        private readonly MedicalInsuranceMap _medicalInsuranceMap;
        private readonly ISystemManageRepository _systemManageRepository;
        private readonly IHisSqlRepository _hisSqlRepository;
        private readonly IMedicalInsuranceSqlRepository _medicalInsuranceSqlRepository;


        public YdMedicalInsuranceService(
            IWebServiceBasicService iWebServiceBasicService,
            IWebBasicRepository webBasicRepository,
            ISystemManageRepository systemManageRepository,
            IHisSqlRepository hisSqlRepository,
            IMedicalInsuranceSqlRepository medicalInsuranceSqlRepository
        )
        {
            _serviceBasicService = iWebServiceBasicService;
            _webBasicRepository = webBasicRepository;
            _medicalInsuranceMap = new MedicalInsuranceMap();
            _systemManageRepository = systemManageRepository;
          
            _hisSqlRepository = hisSqlRepository;
            _medicalInsuranceSqlRepository = medicalInsuranceSqlRepository;
        }

        /// <summary>
        /// 获取门诊职工异地刷卡参数
        /// </summary>
        /// <param name="param"></param>
        public YdBaseParam GetYdOutpatientPayCardParam(
            GetYdOutpatientPayCardParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var result = new YdBaseParam();
            StringBuilder ctrXml = new StringBuilder();
            ctrXml.Append("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\" ?>");
            ctrXml.Append("<row>");
            ctrXml.Append($"<pi_xzqh>{param.AreaCode}</pi_xzqh>");//行政区划
            ctrXml.Append($"<pi_fyze>{param.DownAmount}</pi_fyze>");//费用总额
            ctrXml.Append($"<pi_cardid>{param.InsuranceNo}</pi_cardid>");//费用总额
            ctrXml.Append($"<pi_hklb>1</pi_hklb>");//划卡类别
            ctrXml.Append($"<pi_jbr>{userBase.UserName}</pi_jbr>");//经办人
            ctrXml.Append("</row>");
            result.TransactionCode = "YYJK014";
            result.InputXml = ctrXml.ToString();
            var deleteData = _hisSqlRepository.DeleteDatabase(new DeleteDatabaseParam()
            {
                User = userBase,
                Field = "BusinessId",
                Value = param.BusinessId,
                TableName = "MedicalInsurance"
            });
            var medicalInsurance = new MedicalInsurance()
            {
                Id = Guid.NewGuid(),
                InsuranceNo = param.InsuranceNo,
                AdmissionInfoJson = result.InputXml,
                MedicalInsuranceState = (int)MedicalInsuranceState.MedicalInsurancePreSettlement,
                InsuranceType = 310,
                AreaCode = param.AreaCode,
                IsBirthHospital = false,
                BusinessId = param.BusinessId,

            };

            _medicalInsuranceMap.InsertData(medicalInsurance, userBase);
            return result;
        }
        /// <summary>
        /// 门诊异地划卡
        /// </summary>
        /// <param name="param"></param>
        public WorkerHospitalSettlementCardBackDto YdOutpatientPayCard(GetYdOutpatientPayCardParam param)
        {
            var resultData = new WorkerHospitalSettlementCardBackDto();
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutpatientPayCardXml>(param.SettlementJson);
            //YdOutpatientPayCardXml
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //门诊病人信息存储
            var id = Guid.NewGuid();
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
                Id = id,
                IsSave = true,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            //储存明细
            var outpatientDetailPerson = _serviceBasicService.GetOutpatientDetailPerson(new OutpatientDetailParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
                IsSave = true,
                PatientId = id.ToString()
            });
            var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
            };
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                ReturnOrNewJson = JsonConvert.SerializeObject(outputData),
                RelationId = outpatientParam.Id,
                BusinessId = param.BusinessId,
                Remark = outputData.SerialNumber + "异地刷卡支付"
            });
            //获取医保病人信息
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);
            if (residentData.MedicalInsuranceState != MedicalInsuranceState.MedicalInsurancePreSettlement) throw new Exception("当前病人未办理预结算,不能办理结算!!!");
            //存中间库

            var updateData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = userBase.UserId,
                SelfPayFeeAmount = CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost - outputData.AccountPayAmount),
                OtherInfo = JsonConvert.SerializeObject(resultData),
                Id = residentData.Id,
                SettlementNo = outputData.SerialNumber,
                MedicalInsuranceAllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                SettlementTransactionId = userBase.UserId,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceSettlement,
                SettlementType = "2",
                PatientId = id.ToString()
            };
            //存入中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateData);

            // 回参构建
            var xmlData = new OutpatientDepartmentCostXml()
            {
                AccountBalance = param.AccountBalance,
                MedicalInsuranceOutpatientNo = outputData.SerialNumber,
                CashPayment = outputData.CashPayAmount,
                SettlementNo = outputData.SerialNumber,
                AllAmount = CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost),
                PatientName = outpatientPerson.PatientName,
                AccountAmountPay = outputData.AccountPayAmount,
                MedicalInsuranceType = "1",
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "zydj",
                MedicalInsuranceCode = "48",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);
            var updateParamData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.UserId,
                Id = residentData.Id,
                MedicalInsuranceState = MedicalInsuranceState.HisSettlement,
                IsHisUpdateState = true
            };
            //  更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParamData);
            resultData.AccountBalance = param.AccountBalance;
            resultData.AccountPayment = outputData.AccountPayAmount;
            resultData.CashPayment = outputData.CashPayAmount;

            return resultData;
        }
    }
}
