using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationRegister;
using BenDing.Domain.Models.DifferentPlacesXml.LeaveHospital;
using BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.Workers;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.DifferentPlaces;
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
    /// <summary>
    /// 异地医保服务
    /// </summary>
   public class YdMedicalInsuranceService
    {
        private readonly IWebServiceBasicService _serviceBasicService;
        private readonly IWebBasicRepository _webBasicRepository;
        private MedicalInsuranceMap _medicalInsuranceMap;
        private readonly ISystemManageRepository _systemManageRepository;
        private InpatientMap _inpatientMap; 
        public YdMedicalInsuranceService(
            IWebServiceBasicService iWebServiceBasicService,
            IWebBasicRepository webBasicRepository,
            ISystemManageRepository systemManageRepository
            )
        {
            _serviceBasicService = iWebServiceBasicService;
            _webBasicRepository = webBasicRepository;
            _medicalInsuranceMap = new MedicalInsuranceMap();
            _systemManageRepository = systemManageRepository;
            _inpatientMap= new InpatientMap();  
        }

        ///<summary>
        /// 获取异地入院登记参数
        /// </summary>
        public YdBaseParam GetYdHospitalizationRegisterParam(YdHospitalizationRegisterUiParam param)
        {
            var resultData = new YdBaseParam();
            //his登陆
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var infoData = new GetInpatientInfoParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            };
            //获取医保病人
            var inpatientData = _serviceBasicService.GetInpatientInfo(infoData);
            if (inpatientData == null) throw new Exception("获取医保病人失败!!!");
            var registerParam = GetYdWorkerHospitalizationRegister(param, inpatientData, userBase);
            resultData.TransactionCode = "YYJK003";
            resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(registerParam);
            return resultData;
        }
        ///<summary>
        /// 异地入院登记
        /// </summary>
        public void YdHospitalizationRegister(YdHospitalizationRegisterUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputHospitalizationRegisterXml>(param.SettlementJson);
          //var medicalInsurance=_medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var medicalInsurance = new MedicalInsurance()
            {
                Id = Guid.NewGuid(),
                InsuranceNo = param.InsuranceNo,
                MedicalInsuranceHospitalizationNo = outputData.MedicalInsuranceHospitalizationNo,
                AdmissionInfoJson = param.InputXml,
                MedicalInsuranceState = (int)MedicalInsuranceState.MedicalInsuranceHospitalized,
                InsuranceType = Convert.ToInt32(outputData.InsuranceType),
                AfferentSign="2",
                IdentityMark=param.PersonalNumber,
                AreaCode = param.AreaCode,
                IsBirthHospital = false,
                BusinessId = param.BusinessId,
               
            };

            _medicalInsuranceMap.InsertData(medicalInsurance, userBase);
            //回参构建
            var xmlData = new HospitalizationRegisterXml()
            {
                MedicalInsuranceType = outputData.InsuranceType=="342"?"10": outputData.InsuranceType,
                MedicalInsuranceHospitalizationNo = outputData.MedicalInsuranceHospitalizationNo,
                InsuranceNo = null,
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "zydj",
                MedicalInsuranceCode = "21",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);
            medicalInsurance.MedicalInsuranceState =(int)MedicalInsuranceState.HisHospitalized;
            ////更新中间库
            _medicalInsuranceMap.UpdateState(medicalInsurance);
            var infoData = new GetInpatientInfoParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
                IsSave = true
            };
            //保存入院数据
           
            _serviceBasicService.GetInpatientInfo(infoData);
            //日志
            var logParam = new AddHospitalLogParam
            {
                User = userBase,
                RelationId = medicalInsurance.Id,
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                BusinessId = param.BusinessId,
                ReturnOrNewJson = JsonConvert.SerializeObject(outputData),
                Remark = "医保入院登记"
            };
            _systemManageRepository.AddHospitalLog(logParam);
        }
        /// <summary>
        /// 获取取消入院登记参数
        /// </summary>
        /// <param name="param"></param>
        public YdBaseParam GetYdCancelHospitalizationRegisterParam(UiBaseDataParam param)
        {
            var resultData = new YdBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance=_medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var  inpatient= _inpatientMap.QueryFirstEntity(param.BusinessId);
           
         
            var canCelParam = new YdHospitalizationRegisterCanCelParam()
            {   IdCardNo = inpatient.IdCardNo,
                AreaCode = medicalInsurance.AreaCode,
                PatientName = inpatient.PatientName,
                Operator = userBase.UserName,
                MedicalInsuranceHospitalizationNo = medicalInsurance.MedicalInsuranceHospitalizationNo,
                PersonalNumber = medicalInsurance.IdentityMark,
                
            };
            resultData.TransactionCode = "YYJK004";
            resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(canCelParam);
            return resultData;


        }
        
        /// <summary>
        /// 取消入院登记
        /// </summary>
        /// <param name="param"></param>
        public void YdCancelHospitalizationRegister(UiBaseDataParam param)
        {

            var inpatient = _inpatientMap.QueryFirstEntity(param.BusinessId);
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            //回参构建
            var xmlData = new HospitalizationRegisterCancelXml()
            {
                MedicalInsuranceHospitalizationNo = medicalInsurance.MedicalInsuranceHospitalizationNo
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "CXJB004",
                MedicalInsuranceCode = "22",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = userBase,
                Remark = "基层取消入院登记",
                RelationId = inpatient.Id,
                BusinessId = inpatient.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);

            //取消入院标记
            inpatient.IsCanCelHospitalized = 1;
            ////更新中间库
            _inpatientMap.IsCanCelHospitalized(inpatient);
           

        }

        /// <summary>
        /// 获取出院办理参数
        /// </summary>
        /// <param name="param"></param>
        public YdBaseParam GetYdLeaveHospitalParam(UiBaseDataParam param)
        {
            var resultData = new YdBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var inpatient = _inpatientMap.QueryFirstEntity(param.BusinessId);
            var infoData = new GetInpatientInfoParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            };
            //获取病人结算信息
            var settlementData = _serviceBasicService.GetHisHospitalizationSettlement(infoData);
            var canCelParam = new LeaveHospitalHandleParam()
            {
                AreaCode= medicalInsurance.AreaCode,
                MedicalInsuranceHospitalizationNo = medicalInsurance.MedicalInsuranceHospitalizationNo,
                PersonalNumber = medicalInsurance.IdentityMark,
                
                LeaveHospitalBedNumber = inpatient.LeaveHospitalBedNumber,
                LeaveHospitalDepartmentCode = "0000",
                LeaveHospitalDepartmentName = settlementData.LeaveHospitalDepartmentName,
                LeaveHospitalTime = settlementData.LeaveHospitalDate,
                LeaveHospitalDiagnosisDoctorCode = "",
                LeaveHospitalDiagnosisDoctorName = "",
                LeaveHospitalReason = "",
                LeaveHospitalMedicalRecordNo= inpatient.HospitalizationNo
            };
            //resultData.TransactionCode = "YYJK004";
            //resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(canCelParam);
            return resultData;


        }

        // LeaveHospital
        //UiBaseDataParam
        public YdHospitalizationRegisterParam GetYdWorkerHospitalizationRegister(
            YdHospitalizationRegisterUiParam param, InpatientInfoDto paramDto, UserInfoDto user)
        {
            var diagnosisData = CommonHelp.GetWorkDiagnosis(param.DiagnosisList);
            var diagnosisDataList = param.DiagnosisList.Select(c => new DifferentPlacesOtherDiagnosis
            {
                DiagnosisName = c.DiseaseName,
                DiagnosisCode = c.ProjectCode

            }).ToList();
            var resultData = new YdHospitalizationRegisterParam()
            {
                AdmissionMainDiagnosisIcd10 = diagnosisData.AdmissionMainDiagnosisIcd10,
                DiagnosisIcd10Two = diagnosisData.DiagnosisIcd10Two,
                DiagnosisIcd10Three = diagnosisData.DiagnosisIcd10Three,
                AdmissionMainDiagnosis = diagnosisData.DiagnosisDescribe,
                PersonalNumber = param.PersonalNumber,
                InpatientDepartmentCode= "0000",
                InpatientDepartmentName = paramDto.InDepartmentName,
                DiagnosisList = diagnosisDataList,
                MedicalCategory = param.MedicalCategory,
                MedicalRecordNo =CommonHelp.GuidToStr(paramDto.BusinessId),
                HospitalizationNo= paramDto.HospitalizationNo,
                AdmissionDate= paramDto.AdmissionDate,
                BedNumber= paramDto.AdmissionBed,
                ContactsPhone = paramDto.ContactPhone,
                Operators= paramDto.AdmissionOperator,
                HospitalizedDiagnosisDoctorCode="",
                HospitalizedDiagnosisDoctorName="",
                Contacts= paramDto.ContactName

            };
         
        
            return resultData;
        }
    }
}
