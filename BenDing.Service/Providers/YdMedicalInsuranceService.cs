using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationRegister;
using BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.Workers;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.DifferentPlaces;
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
        public YdMedicalInsuranceService(
            IWebServiceBasicService iWebServiceBasicService,
            IWebBasicRepository webBasicRepository)
        {
           
             _serviceBasicService = iWebServiceBasicService;
            _webBasicRepository = webBasicRepository;
            _medicalInsuranceMap = new MedicalInsuranceMap();
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
                CreateTime = DateTime.Now,
                CreateUserId = param.UserId,
                BusinessId = param.BusinessId,
                IsBirthHospital = false
            };



            //MedicalInsuranceHospitalizationNo = registerData.MedicalInsuranceHospitalizationNo,
            //AfferentSign = param.AfferentSign,
            //IdentityMark = param.IdentityMark
            ////存中间库
            //_medicalInsuranceSqlRepository.SaveMedicalInsurance(userBase, saveData);
            ////回参构建
            //var xmlData = new HospitalizationRegisterXml()
            //{
            //    MedicalInsuranceType = "310",
            //    MedicalInsuranceHospitalizationNo = registerData.MedicalInsuranceHospitalizationNo,
            //    InsuranceNo = null,
            //};
            //var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            //var saveXml = new SaveXmlDataParam()
            //{
            //    User = userBase,
            //    MedicalInsuranceBackNum = "zydj",
            //    MedicalInsuranceCode = "21",
            //    BusinessId = param.BusinessId,
            //    BackParam = strXmlBackParam
            //};
            ////存基层
            //_webBasicRepository.SaveXmlData(saveXml);
            //saveData.MedicalInsuranceState = MedicalInsuranceState.HisHospitalized;
            ////更新中间库
            //_medicalInsuranceSqlRepository.SaveMedicalInsurance(userBase, saveData);
            ////保存入院数据
            //infoData.IsSave = true;
            //_serviceBasicService.GetInpatientInfo(infoData);
            //return registerData;
        }

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
