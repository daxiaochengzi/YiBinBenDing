using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenDing.Domain.Models.DifferentPlacesXml.CancleHospitalizationSettlement;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationPreSettlement;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationRegister;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationSettlement;
using BenDing.Domain.Models.DifferentPlacesXml.LeaveHospital;
using BenDing.Domain.Models.DifferentPlacesXml.PrescriptionUploadCancel;
using BenDing.Domain.Models.DifferentPlacesXml.YdPrescriptionUpload;
using BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.DifferentPlaces;
using BenDing.Domain.Models.Params.Resident;
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
        private readonly MedicalInsuranceMap _medicalInsuranceMap;
        private readonly ISystemManageRepository _systemManageRepository;
        private readonly InpatientMap _inpatientMap;
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
            _inpatientMap= new InpatientMap();
            _hisSqlRepository = hisSqlRepository;
            _medicalInsuranceSqlRepository = medicalInsuranceSqlRepository;
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
           var diagnosisInfo=  CommonHelp.GetDiagnosis(settlementData.DiagnosisList);
            var diagnosisList = settlementData.DiagnosisList.Select(c => new DifferentPlacesLeaveHospitalOtherDiagnosis
            {
                DiagnosisName = c.DiseaseName,
                DiagnosisCode = c.ProjectCode
            }).ToList();
            var canCelParam = new YdInputLeaveHospitalHandleXml()
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
                LeaveHospitalMedicalRecordNo= inpatient.HospitalizationNo,
                LeaveHospitalMainDiagnosisIcd10 = diagnosisInfo.AdmissionMainDiagnosisIcd10,
                LeaveHospitalDiagnosisIcd10Two = diagnosisInfo.DiagnosisIcd10Two,
                LeaveHospitalDiagnosisIcd10Three = diagnosisInfo.DiagnosisIcd10Three,
                LeaveHospitalMainDiagnosis = diagnosisInfo.DiagnosisDescribe,
                DiagnosisList = diagnosisList,
                LeaveHospitalNo= inpatient.HospitalizationNo,
                Operators = userBase.UserName,
                Remarks=""

            };
            resultData.TransactionCode = "YYJK006";
            resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(canCelParam);
            return resultData;


        }
        /// <summary>
        /// 出院办理
        /// </summary>
        /// <param name="param"></param>
        public void YdLeaveHospital(GetYdLeaveHospitalUiParam param)
        {
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputLeaveHospitalHandleXml>(param.SettlementJson);
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            medicalInsurance.LeaveHospitalSerialNumber = outputData.LeaveHospitalSerialNumber;
            medicalInsurance.LeaveHospitalTime =Convert.ToDateTime(outputData.OperationTime) ;
            _medicalInsuranceMap.LeaveHospital(medicalInsurance);
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = userBase,
                Remark = "医保出院办理",
                RelationId = medicalInsurance.Id,
                BusinessId = param.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);

        }
        /// <summary>
        /// 获取取消出院办理参数
        /// </summary>
        /// <param name="param"></param>
        public YdBaseParam GetYdCancelLeaveHospitalParam(UiBaseDataParam param)
        {
            var resultData = new YdBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var inpatient = _inpatientMap.QueryFirstEntity(param.BusinessId);
            StringBuilder ctrXml = new StringBuilder();
            ctrXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>");
            ctrXml.Append("<control>");
            ctrXml.Append($"<baa008>{medicalInsurance.AreaCode}</baa008>");//参保人统筹地区编码
            ctrXml.Append($"<aaz217>{medicalInsurance.MedicalInsuranceHospitalizationNo}</aaz217>");//就诊记录号
            ctrXml.Append($"<aac001>{medicalInsurance.IdentityMark}</aac001>");//个人编号
            ctrXml.Append($"<aac002>{inpatient.IdCardNo}</aac002>");//身份证号
            ctrXml.Append($"<aac003>{inpatient.PatientName}</aac003>");//姓名
            ctrXml.Append($"<bkc131>{userBase.UserName}</bkc131>");//出院经办人
            ctrXml.Append("</control>");
            resultData.TransactionCode = "YYJK007";
            resultData.InputXml = ctrXml.ToString();
            return resultData;


        }
        /// <summary>
        /// 取消出院办理
        /// </summary>
        /// <param name="param"></param>
        public void YdCancelLeaveHospital(GetYdLeaveHospitalUiParam param)
        {
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputLeaveHospitalHandleXml>(param.SettlementJson);
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            medicalInsurance.LeaveHospitalSerialNumber = null;
            medicalInsurance.LeaveHospitalTime = Convert.ToDateTime(outputData.OperationTime);
            _medicalInsuranceMap.LeaveHospital(medicalInsurance);
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = userBase,
                Remark = "取消医保出院办理",
                RelationId = medicalInsurance.Id,
                BusinessId = param.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);

        }

        /// <summary>
        /// 获取异地处方上传参数
        /// </summary>
        /// <param name="param"></param>
        public GetYdPrescriptionUploadParam GetYdPrescriptionUploadParam(GetYdPrescriptionUploadUiParam param)
        {


            //处方上传解决方案
            //1.判断是id上传还是单个用户上传
            //3.获取医院等级判断金额是否符合要求
            //4.数据上传
            //4.1 id上传
            //4.1.2 获取医院等级判断金额是否符合要求
            //4.1.3 数据上传
            //4.1.3.1 数据上传失败,数据回写到日志
            //4.1.3.2 数据上传成功,保存批次号，数据回写至基层
            //4.2   单个病人整体上传
            //4.2.2 获取医院等级判断金额是否符合要求
            //4.2.3 数据上传
            //4.2.3.1 数据上传失败,数据回写到日志
            var isOrganizationCodeUpload = true;
            
            var resultData = new GetYdPrescriptionUploadParam();
            var resultUpload = new RetrunPrescriptionUploadDto();
            var uploadList = new List<YdInputPrescriptionUploadXml>();
            List<QueryInpatientInfoDetailDto> queryData;
            var queryParam = new InpatientInfoDetailQueryParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            //1.判断是id上传还是单个用户上传
            if (param.DataIdList != null && param.DataIdList.Any())
            {
                queryParam.IdList = param.DataIdList;
                queryParam.UploadMark = 0;
                isOrganizationCodeUpload = false;
               
            }
            else
            {
                queryParam.BusinessId = param.BusinessId;
                queryParam.UploadMark = 0;
            }

            //获取病人明细
            queryData = _hisSqlRepository.InpatientInfoDetailQuery(queryParam);
            if (queryData.Any())
            {
                //获取病人医保信息
                var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
                
                    var queryPairCodeParam = new QueryMedicalInsurancePairCodeParam()
                    {
                        DirectoryCodeList = queryData.Select(d => d.DirectoryCode).Distinct().ToList(),
                        OrganizationCode = userBase.OrganizationCode,
                        IsDifferentPlaces = true
                    };
                    //获取医保对码数据
                    var queryPairCode =
                        _medicalInsuranceSqlRepository.QueryMedicalInsurancePairCode(queryPairCodeParam);
                    
                    //获取处方上传入参
                    var paramIni = GetPrescriptionUploadParam(
                        queryData, 
                        queryPairCode,
                        userBase,
                        isOrganizationCodeUpload,
                        param.BusinessId
                        );
                 
                    int num = paramIni.DetailList.RowDataList.Count;
                    resultUpload.Count = num;
                    int a = 0;
                    int limit = 40; //限制条数
                    var count = Convert.ToInt32(num / limit) + ((num % limit) > 0 ? 1 : 0);
                    var idList = new List<Guid>();
                    while (a < count)
                    {
                        //排除已上传数据

                        var rowDataListAll = paramIni.DetailList.RowDataList.Where(d => !idList.Contains(d.Id))
                            .OrderBy(c => c.PrescriptionSort).ToList();
                        var sendList = rowDataListAll.Take(limit).Select(s => s.Id).ToList();
                       
                        var uploadRowParam = new YdInputPrescriptionUploadXml()
                        {
                            Operators = paramIni.Operators,
                            AreaCode = medicalInsurance.AreaCode,
                            PersonalCode = medicalInsurance.IdentityMark,
                            VisitRecordNumber = medicalInsurance.MedicalInsuranceHospitalizationNo
                        };

                        uploadRowParam.DetailList.RowDataList = rowDataListAll.Where(c => sendList.Contains(c.Id)).ToList();
                        uploadRowParam.nums = sendList.Count();
                    ////数据上传
                        uploadList.Add(uploadRowParam);
                       
                        idList.AddRange(sendList);
                        resultUpload.Num += sendList.Count();
                        a++;
                    }

                }
            

            resultData.RetrunUpload = resultUpload;
            resultData.UploadList = uploadList;
            return resultData;

        }

        /// <summary>
        /// 异地处方上传
        /// </summary>
        /// <param name="param"></param>
        public void YdPrescriptionUpload(GetYdPrescriptionUploadUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputPrescriptionUploadXml>(param.SettlementJson);
            var rowXml = param.DataIdList.Select(c => new HospitalizationFeeUploadRowXml() { SerialNumber = c }).ToList();
            //交易码
            var transactionId = Guid.NewGuid().ToString("N");
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
           //更新数据库
            _medicalInsuranceSqlRepository.YdUpdateHospitalizationFee(new YdUpdateHospitalizationFeeParam()
            {
                BatchNumber = CommonHelp.GuidToStr(transactionId),
                User = userBase,
                TransactionId = transactionId,
                IdList = param.DataIdList
            });
            //回参
            var xmlData = new HospitalizationFeeUploadXml()
            {
                MedicalInsuranceHospitalizationNo = medicalInsurance.MedicalInsuranceHospitalizationNo,
                RowDataList = rowXml,
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            userBase.TransKey = param.BusinessId;
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "CXJB004",
                MedicalInsuranceCode = "31",
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
                Remark = "处方上传",
                RelationId = medicalInsurance.Id,
                BusinessId = param.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);

        }
        /// <summary>
        /// 获取异地取消处方上传参数
        /// </summary>
        /// <param name="param"></param>
        public YdIdListBaseParam GetYdCancelPrescriptionUploadParam(GetYdCancelPrescriptionUploadUiParam param)
        {
            var resultData = new YdIdListBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //获取医保病人信息
            var residentDataParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
                OrganizationCode = userBase.OrganizationCode,
            };
            var deleteParam = new YdInputPrescriptionUploadCancelXml();
            List<QueryInpatientInfoDetailDto> queryData;
            //获取病人明细
            var queryDataDetail = _hisSqlRepository.InpatientInfoDetailQuery
                (new InpatientInfoDetailQueryParam() { BusinessId = param.BusinessId });
            //获取选择
            queryData = param.DataIdList != null ? queryDataDetail.Where(c => param.DataIdList.Contains(c.Id.ToString()) && c.UploadMark==1).ToList() : queryDataDetail.Where(d=>d.UploadMark==1).ToList();
            //获取病人医保信息
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(residentDataParam);
            if (queryData.Any())
            {
                deleteParam.VisitRecordNumber = residentData.MedicalInsuranceHospitalizationNo;
                if (param.DataIdList != null && param.DataIdList.Count > 0)
                {
                    deleteParam.PrescriptionNum = CommonHelp.GuidToStr(param.BusinessId);
                    //获取已上传数据、
                    var uploadDataId = queryData.Select(d => new YdPrescriptionUploadCancelRowParam() { PrescriptionSort = d.DataSort }).ToList();
                    deleteParam.DetailList.RowDataList = uploadDataId;
                }
 
            }
            resultData.TransactionCode = "YYJK009";
            resultData.IdList = queryData.Select(c => c.Id.ToString()).ToList();
            resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(deleteParam);
            return resultData;
        }

        /// <summary>
        /// 异地取消处方上传
        /// </summary>
        /// <param name="param"></param>
        public void YdCancelPrescriptionUpload(GetYdCancelPrescriptionUploadUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //获取病人明细
            var queryDataDetail = _hisSqlRepository.InpatientInfoDetailQuery
                (new InpatientInfoDetailQueryParam() { BusinessId = param.BusinessId });
            List<QueryInpatientInfoDetailDto> queryData;
            //获取选择
            queryData = param.DataIdList != null ? queryDataDetail.Where(c => param.DataIdList.Contains(c.Id.ToString())).ToList() : queryDataDetail;
            //更新数据库
            _medicalInsuranceSqlRepository.YdUpdateHospitalizationFee(new YdUpdateHospitalizationFeeParam()
            {
               
                IsDelete = true,
                IdList = param.DataIdList
            });
            //日志
            var joinJson = JsonConvert.SerializeObject(param);
            var logParam = new AddHospitalLogParam
            {
                User = userBase,
                RelationId = Guid.Parse(param.BusinessId),
                JoinOrOldJson = joinJson,
                ReturnOrNewJson = "",
                BusinessId = param.BusinessId,
                Remark = "医保取消处方明细id执行成功"
            };
            _systemManageRepository.AddHospitalLog(logParam);
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            // 回参构建
            var xmlData = new HospitalizationFeeUploadCancelXml()
            {
                MedicalInsuranceHospitalizationNo = medicalInsurance.MedicalInsuranceHospitalizationNo,
                RowDataList = queryData.Select(c => new HospitalizationFeeUploadRowXml() { SerialNumber = c.DetailId }).ToList()
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "CXJB005",
                MedicalInsuranceCode = "32",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);
            //日志
            logParam.Remark = "基层取消处方明细id执行成功";
            _systemManageRepository.AddHospitalLog(logParam);
        }
        /// <summary>
        /// 获取异地住院预结算参数
        /// </summary>
        /// <param name="param"></param>
        public YdBaseParam GetYdHospitalizationPreSettlementParam(GetYdCancelPrescriptionUploadUiParam param)
        {
            var resultData = new YdBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            //获取病人明细
            var queryDataDetail = _hisSqlRepository.InpatientInfoDetailQuery
                (new InpatientInfoDetailQueryParam() { BusinessId = param.BusinessId });
            var infoData = new GetInpatientInfoParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            };
            //获取病人结算信息
            var settlementData = _serviceBasicService.GetHisHospitalizationSettlement(infoData);
            var preSettlementParam = new YdInputHospitalizationPreSettlementXml()
            {
                AreaCode = medicalInsurance.AreaCode,
                Operators = userBase.UserName,
                PersonalCode = medicalInsurance.IdentityMark,
                VisitRecordNumber = medicalInsurance.MedicalInsuranceHospitalizationNo,
                TotalAmount = settlementData.AllAmount,
                Nums = queryDataDetail.Count()//需排除不传医保项目
            };
            resultData.TransactionCode = "YYJK013";
            resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(preSettlementParam);
            return resultData;
        }

        /// <summary>
        /// 异地住院预结算
        /// </summary>
        /// <param name="param"></param>
        public SettlementDto YdHospitalizationPreSettlement(GetYdCancelPrescriptionUploadUiParam param)
        {
            var resultData = new SettlementDto();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputHospitalizationPreSettlementXml>(param.SettlementJson);
            var jsonData = AutoMapper.Mapper.Map<YdHospitalizationPreSettlementJsonDto>(outputData);
            resultData.PayMsg = CommonHelp.GetPayMsg(JsonConvert.SerializeObject(jsonData));
            resultData.CashPayment = jsonData.CashPayAmount;
            //resultData.ReimbursementExpenses = jsonData.ReimbursementExpenses;
            resultData.TotalAmount = jsonData.TotalAmount;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var updateParam = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                ReimbursementExpensesAmount = CommonHelp.ValueToDouble(jsonData.MedicalInsuranceTotalPayAmount),
                SelfPayFeeAmount = resultData.CashPayment,
                OtherInfo = JsonConvert.SerializeObject(resultData),
                Id = medicalInsurance.Id,
                UserId = userBase.UserId,
                SettlementNo = outputData.DocumentNo,
                MedicalInsuranceAllAmount = resultData.TotalAmount,
                PreSettlementTransactionId = userBase.TransKey,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsurancePreSettlement
            };
            //存入中间库
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParam);
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                ReturnOrNewJson = JsonConvert.SerializeObject(resultData),
                User = userBase,
                BusinessId = param.BusinessId,
                Remark = "异地住院病人预结算"
            };
            _systemManageRepository.AddHospitalLog(logParam);
            return resultData;
        }

        /// <summary>
        /// 获取异地住院结算参数
        /// </summary>
        /// <param name="param"></param>
        public YdBaseParam GetYdHospitalizationSettlementParam(GetYdHospitalizationSettlementUiParam param)
        {
           
            var resultData = new YdBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            //获取病人明细
            var queryDataDetail = _hisSqlRepository.InpatientInfoDetailQuery
                (new InpatientInfoDetailQueryParam() { BusinessId = param.BusinessId });
            var infoData = new GetInpatientInfoParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            };
            //获取病人结算信息
            var settlementData = _serviceBasicService.GetHisHospitalizationSettlement(infoData);
            if (medicalInsurance.MedicalInsuranceState !=(int) MedicalInsuranceState.MedicalInsurancePreSettlement) throw new Exception("当前病人未办理预结算,不能办理结算!!!");
            if (medicalInsurance.MedicalInsuranceState == (int)MedicalInsuranceState.HisSettlement) throw new Exception("当前病人已办理医保结算,不能办理再次结算!!!");
            var preSettlementParam = new YdInputHospitalizationSettlementXml()
            {
                AreaCode = medicalInsurance.AreaCode,
                Operators = userBase.UserName,
                PersonalCode = medicalInsurance.IdentityMark,
                VisitRecordNumber = medicalInsurance.MedicalInsuranceHospitalizationNo,
                TotalAmount = settlementData.AllAmount,
                DownAmount= param.DownAmount,
                Nums = queryDataDetail.Count()//需排除不传医保项目
            };
            resultData.TransactionCode = "YYJK011";
            resultData.InputXml = XmlSerializeHelper.HisXmlSerialize(preSettlementParam);
            return resultData;
        }
        /// <summary>
        /// 异地住院结算
        /// </summary>
        /// <param name="param"></param>
        public void YdHospitalizationSettlement(GetYdHospitalizationSettlementUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var inpatient = _inpatientMap.QueryFirstEntity(param.BusinessId);
            var infoData = new GetInpatientInfoParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            };
            //获取his结算
            var hisSettlement = _serviceBasicService.GetHisHospitalizationSettlement(infoData);
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputHospitalizationSettlementXml>(param.SettlementJson);
          // var ReimbursementExpensesAmount= outputData.TotalAmount- outputData.CashPayAmount- outputData.MedicalInsuranceTotalPayAmount

            var updateData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = userBase.UserId,
               // ReimbursementExpensesAmount = CommonHelp.ValueToDouble(outputData.),
                SelfPayFeeAmount = outputData.CashPayAmount,
                OtherInfo = JsonConvert.SerializeObject(outputData),
                Id = medicalInsurance.Id,
                SettlementNo = outputData.DocumentNo,
                MedicalInsuranceAllAmount = outputData.TotalAmount,
                SettlementTransactionId = userBase.UserId,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceSettlement
            };
            //存入中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateData);
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                ReturnOrNewJson = JsonConvert.SerializeObject(outputData),
                User = userBase,
                Remark = "医保异地住院结算",
                RelationId = medicalInsurance.Id,
                BusinessId = param.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);

            //decimal insuranceBalance = !string.IsNullOrWhiteSpace(param.InsuranceBalance) == true
            //    ? Convert.ToDecimal(param.InsuranceBalance) : 0;
            //var cashPayment = CommonHelp.ValueToDouble(hisSettlement.AllAmount - reimbursementExpenses);
            // 回参构建
            var xmlData = new HospitalSettlementXml()
            {

                MedicalInsuranceHospitalizationNo = medicalInsurance.MedicalInsuranceHospitalizationNo,
                CashPayment = outputData.CashPayAmount,
                SettlementNo = outputData.DocumentNo,
                PaidAmount = outputData.PaidAmount,
                AllAmount = outputData.TotalAmount,
                PatientName = inpatient.PatientName,
                AccountBalance = outputData.AccountBalanceAmount,
                AccountAmountPay = outputData.AccountPayAmount,
            };


            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = outputData.DocumentNo,
                MedicalInsuranceCode = "41",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //结算存基层
            _webBasicRepository.SaveXmlData(saveXml);
            //保存结算明细
            _hisSqlRepository.SaveSettlementDetail(new SaveSettlementDetailParam()
            {
                BusinessId = param.BusinessId,
                OutputXml = param.SettlementJson,
                User = userBase,
                LiquidationType = outputData.LiquidationCategory,
                SettlementType = 3,
                SettlementNo = outputData.DocumentNo
            });
       
            //添加日志

            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(xmlData),
                ReturnOrNewJson = "",
                User = userBase,
                Remark = "基层居民住院结算",
                RelationId = medicalInsurance.Id,
                BusinessId = param.BusinessId
            });
            var updateParamData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.UserId,
                Id = medicalInsurance.Id,
                MedicalInsuranceState = MedicalInsuranceState.HisSettlement,
                IsHisUpdateState = true
            };

            //  更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParamData);
            //结算后保存信息
            var saveParam = AutoMapper.Mapper.Map<SaveInpatientSettlementParam>(hisSettlement);
            saveParam.Id = (Guid)medicalInsurance.Id;
            saveParam.User = userBase;
            saveParam.LeaveHospitalDiagnosisJson = JsonConvert.SerializeObject(hisSettlement.DiagnosisList);
            _hisSqlRepository.SaveInpatientSettlement(saveParam);
        }
        /// <summary>
        /// 获取取消异地结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public YdBaseParam GetYdCancelHospitalizationSettlementParam(GetYdHospitalizationSettlementUiParam param)
        {
            var resultData = new YdBaseParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var inpatient = _inpatientMap.QueryFirstEntity(param.BusinessId);
            //基卫操作员登录验证
            StringBuilder ctrXml = new StringBuilder();
            ctrXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?>");
            ctrXml.Append("<control>");
            ctrXml.Append($"<baa008>{medicalInsurance.AreaCode}</baa008>");//参保地统筹区划代码
            ctrXml.Append($"<aac001>{medicalInsurance.IdentityMark}</aac001>");//个人编码
            ctrXml.Append($"<aac002>{inpatient.IdCardNo}</aac002>");//身份证号
            ctrXml.Append($"<aac003>{inpatient.PatientName}</aac003>");//姓名
            ctrXml.Append($"<bkc131>{userBase.UserName}</bkc131>");//经办人
            ctrXml.Append($"<aaz217>{medicalInsurance.MedicalInsuranceHospitalizationNo}</aaz217>");//就诊记录号
            ctrXml.Append($"<aaz216>{medicalInsurance.SettlementNo}</aaz216>");//结算记录号
            ctrXml.Append("</control>");
            resultData.TransactionCode = "YYJK012";
            resultData.InputXml = ctrXml.ToString();

            return resultData;

        }

        /// <summary>
        /// 取消异地结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public void YdCancelHospitalizationSettlement(GetYdHospitalizationSettlementUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var medicalInsurance = _medicalInsuranceMap.QueryFirstEntity(param.BusinessId);
            var outputData =
                XmlSerializeHelper.YdDeSerializer<YdOutputCancelHospitalizationSettlementXml>(param.SettlementJson);
            var updateParam = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = userBase.UserId,
                Id = medicalInsurance.Id,
                CancelTransactionId = userBase.TransKey,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsurancePreSettlement,
                CancelSettlementRemarks = "异地取消单据号:"+ outputData.TransactionSerialNumber
            };
            //存入中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParam);
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = userBase,
                Remark = "异地住院结算取消",
                RelationId = medicalInsurance.Id,
                BusinessId = param.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);
            //回参构建
            var xmlData = new HospitalSettlementCancelXml()
            {
                SettlementNo = medicalInsurance.SettlementNo,
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "CXJB011",
                MedicalInsuranceCode = "42",
                BusinessId = medicalInsurance.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);
            //添加日志

            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(xmlData),
                User = userBase,
                Remark = "基层居民住院结算取消",
                RelationId = medicalInsurance.Id,
                BusinessId = medicalInsurance.BusinessId,
            });
        }

        /// <summary>
        /// 获取处方上传入参
        /// </summary>
        /// <returns></returns>
        private YdInputPrescriptionUploadXml GetPrescriptionUploadParam(
            List<QueryInpatientInfoDetailDto> param,
            List<QueryMedicalInsurancePairCodeDto> pairCodeList, 
            UserInfoDto user,
            bool isOrganizationCodeUpload,
            string businessId )
        {

            var resultData = new YdInputPrescriptionUploadXml();

            resultData.Operators = CommonHelp.GuidToStr(user.UserId);
            var rowDataList = new List<YdPrescriptionUploadRowParam>();
            foreach (var item in param)
            {
                var pairCodeData = pairCodeList.FirstOrDefault(c => c.DirectoryCode == item.DirectoryCode);

                if (pairCodeData != null)
                {
                    var rowData = new YdPrescriptionUploadRowParam()
                    {
                        PrescriptionNum=CommonHelp.GuidToStr(businessId),
                        MedicalAdvice= item.DataSort.ToString(),
                        PrescriptionSort= item.DataSort.ToString(),
                        ProjectCode= pairCodeData.ProjectCode,
                        FixedEncoding = pairCodeData.FixedEncoding,
                        ProjectName= item.DirectoryName,
                        ProjectCodeType = pairCodeData.ProjectCodeType,
                        Quantity=item.Quantity,
                        UnitPrice= item.UnitPrice,
                        Amount=item.Amount,
                        Unit=item.Unit,
                        Formulation=item.Formulation,
                        Specification=item.Specification,
                        Dosage=Convert.ToDecimal(item.Dosage),
                        Usage= item.Usage,
                        ManufacturerName= pairCodeData.Manufacturer,
                        DoctorJobNumber="",
                        DoctorName=item.BillDoctorName,
                        InDepartmentName= item.OperateDepartmentName,
                        DirectoryDate= CommonHelp.FormatDateTime(item.BillTime),
                       
                    };
                    //是否现在使用药品
                    if (pairCodeData.RestrictionSign == "1")
                    {
                        if (isOrganizationCodeUpload == false)
                        {
                            if (item.ApprovalMark == 0)
                            {
                                throw new Exception(item.DirectoryName + "为限制性药品未审核");
                            }
                          
                            rowData.LimitApprovalMark = item.ApprovalMark.ToString();
                        }



                    }

                    if (isOrganizationCodeUpload == true &&
                        pairCodeData.RestrictionSign == "1"
                        && item.ApprovalMark == 0)
                    {
                        //不做处理
                    }
                    else
                    {
                        rowDataList.Add(rowData);
                    }

                    

                }
                


            }

            resultData.DetailList.RowDataList = rowDataList;
            return resultData;

        }
        private YdHospitalizationRegisterParam GetYdWorkerHospitalizationRegister(
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
