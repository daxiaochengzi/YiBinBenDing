using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BenDing.Domain.Models.Dto;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Dto.JsonEntity;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.DifferentPlaces;
using BenDing.Domain.Models.Params.OutpatientDepartment;
using BenDing.Domain.Models.Params.Resident;
using BenDing.Domain.Models.Params.SystemManage;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Xml;
using BenDing.Repository.Interfaces.Web;
using BenDing.Repository.Providers.Web;
using BenDing.Service.Interfaces;
using Newtonsoft.Json;
using NFine.Code;
using NFine.Web.Model;


namespace NFine.Web.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    public class TestController : ApiController
    {
        private readonly IUserService userService;
        private readonly IWebServiceBasicService webServiceBasicService;
        private readonly IWebBasicRepository webServiceBasic;
        private readonly IHisSqlRepository hisSqlRepository;
        private readonly ISystemManageRepository _systemManageRepository;
        private readonly IMedicalInsuranceSqlRepository ImedicalInsuranceSqlRepository;
        private readonly ISqlSugarRepository _sqlSugarRepository;
        private  HospitalLogMap _hospitalLogMap;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userService"></param>
        /// <param name="_webServiceBasicService"></param>
        /// <param name="_WebBasicRepository"></param>
        /// <param name="_hisSqlRepository"></param>
        /// <param name="_imedicalInsuranceSqlRepository"></param>
        public TestController(IUserService _userService,
            IWebServiceBasicService _webServiceBasicService,
            IWebBasicRepository _WebBasicRepository,
            IHisSqlRepository _hisSqlRepository,
            IMedicalInsuranceSqlRepository _imedicalInsuranceSqlRepository,
            ISystemManageRepository systemManageRepository,
             ISqlSugarRepository sqlSugarRepository
            )
        {
            userService = _userService;
            webServiceBasicService = _webServiceBasicService;
            webServiceBasic = _WebBasicRepository;
            hisSqlRepository = _hisSqlRepository;
            ImedicalInsuranceSqlRepository = _imedicalInsuranceSqlRepository;
            _systemManageRepository = systemManageRepository;
            _sqlSugarRepository = sqlSugarRepository;
            _hospitalLogMap = new HospitalLogMap();
        }

        /// <summary>
        /// 测试专用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData TestData()
        {
            return new ApiJsonResultData().RunWithTry(y =>
            {
                string sss= "<ROW xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>";

                sss += @"  <PI_CRBZ>2</PI_CRBZ>
                      <PI_SFBZ>1027384812</PI_SFBZ>
                      <PI_YLLB>11</PI_YLLB>
                      <PI_RYRQ>20200909</PI_RYRQ>
                      <PI_ICD10>I10.x05</PI_ICD10>
                      <PI_ICD10_2>K81.000</PI_ICD10_2>
                      <PI_ICD10_3>M51.202</PI_ICD10_3>
                      <PI_RYZD>高血压3级,急性胆囊炎,腰间盘突出</PI_RYZD>
                      <PI_ZYBQ>综合科</PI_ZYBQ>
                      <PI_CWH>36</PI_CWH>
                      <PI_YYZYH>100220200907002</PI_YYZYH>
                      <PI_JBR>李茜</PI_JBR>
                    </ROW>";
                string mzNo = "451238747000M202006020001";
                string[] arr = mzNo.Split('M');
                string mz = arr[1];
                //var ddd = Guid.Parse("16DEABB5A8E242A980444AC130913431");
                //var resultStr = XmlHelp.DeSerializerXmlInfo("123");
                //var iniData = XmlHelp.DeSerializer<OutpatientDepartmentCostInputJsonDto>(resultStr);
                //HospitalizationPresettlementDto data = null;
                //var dataIni = XmlHelp.DeSerializerModel(new HospitalizationPresettlementJsonDto(), true);
                //data = AutoMapper.Mapper.Map<HospitalizationPresettlementDto>(dataIni);
                ////报销金额 =统筹支付+补充险支付+生育补助+民政救助+民政重大疾病救助+精准扶贫+民政优抚+其它支付
                //decimal reimbursementExpenses =
                //    data.BasicOverallPay + data.SupplementPayAmount + data.BirthAAllowance +
                //    data.CivilAssistancePayAmount + data.CivilAssistanceSeriousIllnessPayAmount +
                //    data.AccurateAssistancePayAmount + data.CivilServicessistancePayAmount +
                //    data.OtherPaymentAmount;
                //data.ReimbursementExpenses = reimbursementExpenses;

                //var datacc= CommonHelp.GetPayMsg(JsonConvert.SerializeObject(data));
                //y.Data = datacc;      
            });

        }

        [HttpGet]
        public ApiJsonResultData PageList([FromUri] UserInfo pagination)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var paramList = new List<DifferentPlacesOtherDiagnosis>();
                var param = new DifferentPlacesHospitalizationRegisterParam()
                {
                    AdmissionDate = "123123",
                    DiagnosisList = paramList,

                };
                paramList.Add(new DifferentPlacesOtherDiagnosis()
                {
                    DiagnosisCode = "123",
                    DiagnosisName = "sss"
                });
                paramList.Add(new DifferentPlacesOtherDiagnosis()
                {
                    DiagnosisCode = "13323",
                    DiagnosisName = "ss333s"
                });
                var xmlStr = XmlHelp.SaveXml(param);
                //y.DataDescribe = CommonHelp.GetPropertyAliasDict(new UserInfoDto());
                //y.Data = userService.GetUserInfo();

            });

        }

        /// <summary>
        /// post测试
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData PageListPost([FromBody] UserInfo pagination)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {

                //y.DataDescribe = CommonHelp.GetPropertyAliasDict(new UserInfoDto());
                //y.Data = userService.GetUserInfo();
                y.Data = "123";
                

            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData GetUserInfoLogin([FromBody] GetUserInfoLoginUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var inputParam = new UserInfoParam()
                {
                    UserName = param.UserName,
                    Pwd = param.pwd,
                    ManufacturerNumber = "510303001",
                };
                string inputParamJson = JsonConvert.SerializeObject(inputParam, Formatting.Indented);
                var verificationCode = webServiceBasicService.GetVerificationCode("01", inputParamJson);
                y.Data = verificationCode;


                //var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
                //{
                //    BusinessId = "26F6B97CE2F2494182B6CB7942BBA96F",
                //    MedicalInsuranceState = 3
                //};
                //var residentData = ImedicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);

            });

        }

        #region  	3.5.2 	获取检查报告列表

        /// <summary>
        ///	javaPost测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> GetPostUrl([FromBody] UiInIParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {

                //var requestJson = JsonConvert.SerializeObject("{'orderAmt':0.01,'token':'134757426273844039'}");

                var paramData = new GetPostUrlDto();
                paramData.orderAmt = Convert.ToDecimal(0.01);
                paramData.token = "134757426273844039";
                string content = JsonConvert.SerializeObject(paramData);
                //第一种方法
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.ExpectContinue = false;
                var response = await httpClient.PostAsync("http://triage.natapp1.cc/scrcu/pay/order", byteContent)
                    .ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();



                //第二种方法
                byte[] byteArray = Encoding.Default.GetBytes(content); //转化
                HttpWebRequest webReq =
                    (HttpWebRequest) WebRequest.Create(new Uri("http://triage.natapp1.cc/scrcu/pay/order"));
                webReq.Method = "POST";

                webReq.ServicePoint.Expect100Continue = false;
                webReq.ContentType = "application/json";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length); //写入参数
                newStream.Close();
                HttpWebResponse responsebbb = (HttpWebResponse) webReq.GetResponse();
                StreamReader sr = new StreamReader(responsebbb.GetResponseStream(), Encoding.UTF8);
                var ret = sr.ReadToEnd();
                sr.Close();
                responsebbb.Close();
                newStream.Close();




            });
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData MedicalInsuranceXml([FromUri] MedicalInsuranceXmlUiParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                //更新医保信息
                var strXmlIntoParam = XmlSerializeHelper.XmlParticipationParam();
                //回参构建
                var xmlData = new HospitalizationRegisterXml()
                {
                    MedicalInsuranceType = "10",
                    MedicalInsuranceHospitalizationNo = "44116476",
                };

                var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                var saveXmlData = new SaveXmlData();
                saveXmlData.OrganizationCode = userBase.OrganizationCode;
                saveXmlData.AuthCode = userBase.AuthCode;
                saveXmlData.BusinessId = param.BusinessId;
                saveXmlData.TransactionId = Guid.Parse("E67C69F5-5FA8-438A-94EC-85E092CA56E9").ToString("N");
                saveXmlData.MedicalInsuranceBackNum = "CXJB002";
                saveXmlData.BackParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                saveXmlData.IntoParam = CommonHelp.EncodeBase64("utf-8", strXmlIntoParam);
                saveXmlData.MedicalInsuranceCode = "21";
                saveXmlData.UserId = userBase.UserId;
                //存基层
                webServiceBasic.HIS_InterfaceList("38", JsonConvert.SerializeObject(saveXmlData));
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData MedicalInsuranceXmlCancel([FromUri] MedicalInsuranceXmlUiParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;
                //回参构建
                var xmlData = new HospitalSettlementCancelXml()
                {
                    SettlementNo = param.SettlementNo,
                };
                var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                var saveXml = new SaveXmlDataParam()
                {
                    User = userBase,
                    MedicalInsuranceBackNum = "CXJB011",
                    MedicalInsuranceCode = "42",
                    BusinessId = param.BusinessId,
                    BackParam = strXmlBackParam
                };
                //存基层
                webServiceBasic.SaveXmlData(saveXml);
                //var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                ////更新医保信息
                //var strXmlIntoParam = XmlSerializeHelper.XmlParticipationParam();
                ////回参构建
                //var xmlData = new HospitalizationRegisterCancelXml()
                //{

                //    MedicalInsuranceHospitalizationNo = "44116476",

                //};

                //var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                //var saveXmlData = new SaveXmlData();
                //saveXmlData.OrganizationCode = userBase.OrganizationCode;
                //saveXmlData.AuthCode = userBase.AuthCode;
                //saveXmlData.BusinessId = param.BusinessId;
                //saveXmlData.TransactionId = Guid.Parse("EA144C5D-1146-4229-87FB-7D9EEA0B3F78").ToString("N");
                //saveXmlData.MedicalInsuranceBackNum = "CXJB003";
                //saveXmlData.BackParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                //saveXmlData.IntoParam = CommonHelp.EncodeBase64("utf-8", strXmlIntoParam);
                //saveXmlData.MedicalInsuranceCode = "22";
                //saveXmlData.UserId = userBase.UserId;
                ////存基层
                //webServiceBasic.HIS_InterfaceList("38", JsonConvert.SerializeObject(saveXmlData));
            });

        }

        /// <summary>
        /// 取消医保结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData MedicalInsuranceXmlCancelSettlement([FromUri] MedicalInsuranceXmlUiParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;

                //回参构建
                var xmlData = new OutpatientDepartmentCostCancelXml()
                {
                    SettlementNo = param.SettlementNo
                };
                var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                var saveXml = new SaveXmlDataParam()
                {
                    User = userBase,
                    MedicalInsuranceBackNum = "Qxjs",
                    MedicalInsuranceCode = "42MZ",
                    BusinessId = param.BusinessId,
                    BackParam = strXmlBackParam
                };
                //存基层
                webServiceBasic.SaveXmlData(saveXml);

                ////回参构建
                //var xmlData = new HospitalSettlementCancelXml()
                //{
                //    SettlementNo = param.SettlementNo,
                //};
                //var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                //var saveXml = new SaveXmlDataParam()
                //{
                //    User = userBase,
                //    MedicalInsuranceBackNum = "CXJB011",
                //    MedicalInsuranceCode = "42",
                //    BusinessId = param.BusinessId,
                //    BackParam = strXmlBackParam
                //};
                ////存基层
                //webServiceBasic.SaveXmlData(saveXml);

                //var ddd = "123";
                ////更新医保信息
                //var strXmlIntoParam = XmlSerializeHelper.XmlParticipationParam();
                ////回参构建
                //var xmlData = new HospitalSettlementCancelXml()
                //{


                //    SettlementNo = param.SettlementNo
                //};

                //var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                //var saveXmlData = new SaveXmlData();
                //saveXmlData.OrganizationCode = userBase.OrganizationCode;
                //saveXmlData.AuthCode = userBase.AuthCode;
                //saveXmlData.BusinessId = param.BusinessId;
                //saveXmlData.TransactionId =param.TransKey;
                //saveXmlData.MedicalInsuranceBackNum = "CXJB003";
                //saveXmlData.BackParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                //saveXmlData.IntoParam = CommonHelp.EncodeBase64("utf-8", strXmlIntoParam);
                //saveXmlData.MedicalInsuranceCode = "42";
                //saveXmlData.UserId = userBase.UserId;
                ////存基层
                //webServiceBasic.HIS_InterfaceList("38", JsonConvert.SerializeObject(saveXmlData));
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData MedicalInsuranceXmlUpload([FromUri] MedicalInsuranceXmlUiParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);

                var hospitalizationFeeList = hisSqlRepository.InpatientInfoDetailQuery(
                    new InpatientInfoDetailQueryParam() {BusinessId = param.BusinessId});


                var rowXml = hospitalizationFeeList.Where(d => d.UploadMark == 0).Select(c =>
                    new HospitalizationFeeUploadRowXml()
                    {
                        SerialNumber = c.DetailId
                    }).ToList();


                var xmlData = new HospitalizationFeeUploadXml()
                {

                    MedicalInsuranceHospitalizationNo = "44116476",
                    RowDataList = rowXml,
                };
                var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                //
                var transactionId = Guid.Parse("79D71ACA-EDBB-419C-A382-2271922E708D").ToString("N");
                var saveXmlData = new SaveXmlData();
                saveXmlData.OrganizationCode = userBase.OrganizationCode;
                saveXmlData.AuthCode = userBase.AuthCode;
                saveXmlData.BusinessId = param.BusinessId;
                saveXmlData.TransactionId = transactionId;
                saveXmlData.MedicalInsuranceBackNum = "CXJB004";
                saveXmlData.BackParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                saveXmlData.IntoParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                saveXmlData.MedicalInsuranceCode = "31";
                saveXmlData.UserId = userBase.UserId;
                webServiceBasic.HIS_InterfaceList("38", JsonConvert.SerializeObject(saveXmlData));
            });

        }

        /// <summary>
        /// 测试xml生成
        /// </summary>
        [HttpGet]
        public ApiJsonResultData TestXml([FromUri] MedicalInsuranceXmlUiParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var checkData = Regex.IsMatch(param.SettlementNo, @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase);
                var settlementJson = "{\"SerialNumber\": \"101080551392\", 	\"AccountPayment\": 0.03, 	\"CashPayment\": 0.0, 	\"AccountBalance\": 386.7 }";
                var iniData = JsonConvert.DeserializeObject<WorkerHospitalSettlementCardBackDataDto>(settlementJson);
            //var data = XmlHelp.DeSerializerModel(new BenDing.Domain.Models.Dto.OutpatientDepartment.QueryOutpatientDepartmentCostDto(), true);
            //if (data == null) throw new Exception("门诊费用查询出错");
            //var cc = AutoMapper.Mapper.Map<QueryOutpatientDepartmentCostjsonDto>(data);
            //var ddd = new List<InpatientDiagnosisDto>();

            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = false,
            //    ProjectCode = "T82.201",
            //    DiseaseName = "冠状动脉搭桥术机械性并发症"
            //});
            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = false,
            //    ProjectCode = "T82.812",
            //    DiseaseName = "主动脉机械瓣周漏"
            //});
            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = true,
            //    ProjectCode = "T82.003",
            //    DiseaseName = "主漏"
            //});
            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = false,
            //    ProjectCode = "T83.304",
            //    DiseaseName = "子宫内节育器脱落"
            //});
            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = false,
            //    ProjectCode = "T84.502",
            //    DiseaseName = "膝关节假体植入感染"
            //});
            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = false,
            //    ProjectCode = "T83.304",
            //    DiseaseName = "子宫内节育器脱落"
            //});
            //ddd.Add(new InpatientDiagnosisDto()
            //{
            //    IsMainDiagnosis = false,
            //    ProjectCode = "T84.502",
            //    DiseaseName = "膝关节假体植入感染"
            //});

            //  
            //var tableData=  CommonHelp.ObjectToTable(ddd);
            // ExcelHelper.Export(tableData, "医保对码表", "c:\\成中荣新繁出差.xlsx");
            //var dds = CommonHelp.GetDiagnosis(ddd);





            var ddd = new List<InpatientDiagnosisDto>();

            ddd.Add(new InpatientDiagnosisDto()
            {
                IsMainDiagnosis = false,
                ProjectCode = "1假体植入",
                DiseaseName = "1"
            });
            ddd.Add(new InpatientDiagnosisDto()
            {
                IsMainDiagnosis = false,
                ProjectCode = "2膝关节假体植入",
                DiseaseName = "2"
            });
            ddd.Add(new InpatientDiagnosisDto()
            {
                IsMainDiagnosis = true,
                ProjectCode = "3膝关节假体植入",
                DiseaseName = "3"
            });
            ddd.Add(new InpatientDiagnosisDto()
            {
                IsMainDiagnosis = false,
                ProjectCode = "4膝关节假体植入",
                DiseaseName = "4"
            });
            var dds = CommonHelp.LeaveHospitalDiagnosis(ddd);
                    y.Data = dds;
             });

        }

        /// <summary>
        /// 基层预结算测试
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData HisPreSettlement([FromUri] BaseUiBusinessIdDataParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {

                //var dd = new ResidentUserInfoParam {IdentityMark = "1", InformationNumber = "111"};
                //var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                //var strXmlIntoParam = XmlSerializeHelper.XmlSerialize(dd);
                //var strXmlBackParam = XmlSerializeHelper.XmlSerialize(dd);
                //var saveXmlData = new SaveXmlData();
                //saveXmlData.OrganizationCode = userBase.OrganizationCode;
                //saveXmlData.AuthCode = userBase.AuthCode;
                //saveXmlData.BusinessId = param.BusinessId;
                //saveXmlData.TransactionId = param.BusinessId;
                //saveXmlData.MedicalInsuranceBackNum = "CXJB009";
                //saveXmlData.BackParam = CommonHelp.EncodeBase64("utf-8", strXmlIntoParam);
                //saveXmlData.IntoParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                //saveXmlData.MedicalInsuranceCode = "43";
                //saveXmlData.UserId = param.UserId;
                //webServiceBasic.HIS_InterfaceList("38", JsonConvert.SerializeObject(saveXmlData));

            });
        }

        /// <summary>
        /// 基层结算测试
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData Settlement([FromUri] BaseUiBusinessIdDataParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;
                //54901231
                //回参构建
                var xmlData = new OutpatientDepartmentCostXml()
                {
                    AccountBalance = 0,
                    MedicalInsuranceOutpatientNo = "54901231",
                    CashPayment = Convert.ToDecimal(-295.2),
                    SettlementNo = "54901231",
                    AllAmount = Convert.ToDecimal(4.8),
                    PatientName = "陈继美",
                    AccountAmountPay = 0,
                    MedicalInsuranceType = "345",
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
                webServiceBasic.SaveXmlData(saveXml);
                //var dd = new ResidentUserInfoParam { IdentityMark = "1", InformationNumber = "111" };
                //var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                //var strXmlIntoParam = XmlSerializeHelper.XmlSerialize(dd);
                //var strXmlBackParam = XmlSerializeHelper.XmlSerialize(dd);
                //var saveXmlData = new SaveXmlData();
                //saveXmlData.OrganizationCode = userBase.OrganizationCode;
                //saveXmlData.AuthCode = userBase.AuthCode;
                //saveXmlData.BusinessId = param.BusinessId;
                //saveXmlData.TransactionId = param.BusinessId;
                //saveXmlData.MedicalInsuranceBackNum = "CXJB009";
                //saveXmlData.BackParam = CommonHelp.EncodeBase64("utf-8", strXmlIntoParam);
                //saveXmlData.IntoParam = CommonHelp.EncodeBase64("utf-8", strXmlBackParam);
                //saveXmlData.MedicalInsuranceCode = "41";
                //saveXmlData.UserId = param.UserId;
                // webServiceBasic.HIS_InterfaceList("38", JsonConvert.SerializeObject(saveXmlData));



            });
        }

        ///// <summary>
        ///// 医院三大目录批量上传
        ///// </summary>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ApiJsonResultData HospitalThreeCatalogBatchUpload([FromBody] UiInIParam param)
        //{
        //    return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
        //    {
        //        var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);

        //        var paramIni = new MedicalInsurancePairCodesUiParam();

        //        if (userBase != null && string.IsNullOrWhiteSpace(userBase.OrganizationCode) == false)
        //        {
        //            paramIni.OrganizationCode = userBase.OrganizationCode;
        //            paramIni.OrganizationName = userBase.OrganizationName;

        //            webServiceBasicService.ThreeCataloguePairCodeUpload(
        //                new UpdateThreeCataloguePairCodeUploadParam()
        //                {
        //                    User = userBase,
        //                    ProjectCodeList = new List<string>()
        //                }
        //            );

        //        }

        //        ImedicalInsuranceSqlRepository.HospitalThreeCatalogBatchUpload(userBase);

        //    });

        //}

        /// <summary>
        /// icd10批量上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData Icd10BatchUpload([FromBody] UiBaseDataParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;
                var dataList = new List<Icd10PairCodeDataParam>();

                //基层
                var queryDataNew = _sqlSugarRepository.QueryICD10PairCode();
                var queryData = queryDataNew.Where(c => c.IsDelete == false && c.State==0).ToList();
                if (queryData.Any())
                {
                    dataList = queryData.Select(d => new Icd10PairCodeDataParam
                    {
                        DiseaseId = d.DiseaseId,
                        ProjectName = d.ProjectName,
                        ProjectCode = d.ProjectCode
                    }).ToList();
                }

                if (dataList.Any())
                {
                    int a = 0;
                    int limit = 400; //限制条数
                    int num = dataList.Count;
                    var count = Convert.ToInt32(num / limit) + ((num % limit) > 0 ? 1 : 0);
                    var idList = new List<string>();
                    while (a < count)
                    {
                        //排除已上传数据

                        var rowDataListAll = dataList.Where(d => !idList.Contains(d.DiseaseId))
                            .ToList();
                        var sendList = rowDataListAll.Take(limit).ToList();


                        //回参构建
                        var icd10List = new List<Icd10PairCodeDateXml>();
                        icd10List.AddRange(sendList.Select(c => new Icd10PairCodeDateXml()
                        {
                            DiseaseId = c.DiseaseId,
                            DiseaseName = c.ProjectName,
                            DiseaseCoding = c.ProjectCode
                        }));

                        var xmlData = new Icd10PairCodeXml()
                        {
                            row = icd10List
                        };
                        var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
                        var saveXml = new SaveXmlDataParam()
                        {
                            User = userBase,
                            MedicalInsuranceBackNum = "CXJB002",
                            MedicalInsuranceCode = "91",
                            BusinessId = param.BusinessId,
                            BackParam = strXmlBackParam
                        };
                        //存基层
                        webServiceBasic.SaveXmlData(saveXml);
                        idList.AddRange(sendList.Select(c=>c.DiseaseId));
                        a++;
                    }


                    hisSqlRepository.ExecuteSql("update [dbo].[ICD10PairCode] set state=1 where  [PairCodeUserName]='医保接口对码'");
                }



            });

        }
        /// <summary>
        /// 医保三大目录批量对码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData MedicalInsurancePairCode([FromBody]UiInIParam param)
        {
            return new ApiJsonResultData(ModelState, new MedicalInsurancePairCodesUiParam()).RunWithTry(y =>
            {

                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                if (userBase != null && string.IsNullOrWhiteSpace(userBase.OrganizationCode) == false)
                {
                    var data = webServiceBasicService.ThreeCataloguePairCodeUpload(
                           new UpdateThreeCataloguePairCodeUploadParam()
                           {
                               User = userBase,
                               ProjectCodeList = new List<string>()
                           }
                       );
                    y.Data = data;
                }

            });

        }
        [HttpPost]
        public ApiJsonResultData OutpatientDepartmentCostInput([FromBody] OutpatientPlanBirthSettlementUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;
                var json =
                    "{\"发生费用金额\":0.0250,\"生育补助\":500.0,\"基本统筹支付\":0.0,\"补充医疗保险支付金额\":0.0,\"公务员补贴\":0.0,\"公务员补助\":0.0,\"其它支付金额\":0.0,\"账户支付\":0.0,\"现金支付\":0.0,\"起付金额\":0.0}";
                //var iniData = JsonConvert.DeserializeObject<WorkerBirthPreSettlementJsonDto>(json);
                var resultData = JsonConvert.DeserializeObject<WorkerBirthSettlementDto>(json);
                
                  var ccc = new GetOutpatientPersonParam()
                {
                    User = userBase,
                    UiParam = param,
                    IdentityMark = param.IdentityMark,
                    AfferentSign = param.AfferentSign,
                    InsuranceType = param.InsuranceType,
                    AccountBalance = param.AccountBalance,
                    SettlementXml = param.SettlementJson,
                };
                //获取门诊病人数据
                var outpatientPerson = webServiceBasicService.GetOutpatientPerson(ccc);
                var accountPayment = resultData.AccountPayment + resultData.CivilServantsSubsidies +
                                     resultData.CivilServantsSubsidy + resultData.OtherPaymentAmount +
                                     resultData.BirthAllowance + resultData.SupplementPayAmount;
                var cashPayment = CommonHelp.ValueToDouble((outpatientPerson.MedicalTreatmentTotalCost - accountPayment));
                // 回参构建
                var xmlData = new OutpatientDepartmentCostXml()
                {
                    AccountBalance = !string.IsNullOrWhiteSpace(param.AccountBalance) == true ? Convert.ToDecimal(param.AccountBalance) : 0,
                    MedicalInsuranceOutpatientNo = "54901231",
                    CashPayment = cashPayment <0?0: cashPayment,
                    SettlementNo = "54901231",
                    AllAmount =CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost),
                    PatientName = "代美玲",
                    AccountAmountPay = 0,
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
                ////存基层
               webServiceBasic.SaveXmlData(saveXml);
            });
        }

        /// <summary>
        /// 取消门诊费用结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData CancelOutpatientDepartmentCost([FromUri]CancelOutpatientDepartmentCostUiParam param)
        {
            return new ApiJsonResultData(ModelState).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;
                var xmlData = new MedicalInsuranceXmlDto();
                xmlData.BusinessId = param.BusinessId;
                xmlData.HealthInsuranceNo = "42";//42MZ
                xmlData.TransactionId = param.TransKey;
                xmlData.AuthCode = userBase.AuthCode;
                xmlData.UserId = param.UserId;
                xmlData.OrganizationCode = userBase.OrganizationCode;
                var jsonParam = JsonConvert.SerializeObject(xmlData);
                var data = webServiceBasic.HIS_Interface("39", jsonParam);
                HisHospitalizationSettlementCancelJsonDto dataValue = JsonConvert.DeserializeObject<HisHospitalizationSettlementCancelJsonDto>(data.Msg);
                //{\"基础信息\":{\"ORGID\":\"9F44A548B22A4F84BC59A59FF4796D53\",\"YBCODE\":\"123\",\"INFID\":\"6F63E04260974852B0F461D6108DB688\",\"结算编号\":\"34556\",\"就诊编号\":\"34556\",\"经办人\":\"医保接口\"}}
                ////回参构建
                var xmlDatas = new OutpatientDepartmentCostCancelXml()
                {
                    SettlementNo = dataValue.InfoData.SettlementNo
                };
                var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlDatas);
                var saveXml = new SaveXmlDataParam()
                {
                    User = userBase,
                    MedicalInsuranceBackNum = "Qxjs",
                    MedicalInsuranceCode = "42MZ",
                    BusinessId = param.BusinessId,
                    BackParam = strXmlBackParam
                };
                //存基层
                webServiceBasic.SaveXmlData(saveXml);
                //_outpatientDepartmentNewService.CancelOutpatientDepartmentCost(param);
            });

        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData OutpatientSettlement([FromBody] UiBaseDataParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                userBase.TransKey = param.TransKey;
                //回参构建88866
                var xmlData = new OutpatientDepartmentCostXml()
                {
                    AccountBalance = 10,
                    MedicalInsuranceOutpatientNo = "88866",
                    CashPayment = 0,
                    SettlementNo = "88866",
                    AllAmount = Convert.ToDecimal(0.07),
                    PatientName = "代美玲",
                    AccountAmountPay = 0,
                    MedicalInsuranceType = "342"
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
                webServiceBasic.SaveXmlData(saveXml);

            });

        }
        /// <summary>
        /// 获取住院病人明细费用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData GetInpatientInfoDetail([FromUri]GetInpatientInfoDetailParam param)
        {
            return new ApiJsonResultData(ModelState, new InpatientInfoDetailDto()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
                var xmlData = new MedicalInsuranceXmlDto();
                var transactionId = Guid.NewGuid().ToString("N");
                xmlData.BusinessId =param.BusinessId ;
                xmlData.HealthInsuranceNo = "31";
                xmlData.TransactionId = transactionId;
                xmlData.AuthCode = userBase.AuthCode;
                xmlData.UserId = userBase.UserId;
                xmlData.OrganizationCode = userBase.OrganizationCode;
                var data = webServiceBasic.HIS_Interface("39", JsonConvert.SerializeObject(xmlData));

            });

        }
        /// <summary>
        /// 下载文件
        /// </summary>
        [HttpGet]
        public HttpResponseMessage DownloadFileExcel()
        {//c:\\成中荣新繁出差.xlsx
            string fileName = "成中荣新繁出差.xlsx";
            string filePath = HttpContext.Current.Server.MapPath("~/") + "FileExcel/成中荣新繁出差.xlsx";
            FileStream stream = new FileStream(filePath, FileMode.Open);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = HttpUtility.UrlEncode(fileName)
            };
            response.Headers.Add("Access-Control-Expose-Headers", "FileName");
            response.Headers.Add("FileName", HttpUtility.UrlEncode(fileName));
            stream.Close();
            return response;

        }

        /// <summary>
        /// 获取住院病人明细费用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void TestSqlSugar()
        {
            string ddd =
                "{\"ORGID\":\"10ADC4A48AB743A2B532AD8D08C4B927\",\"YBCODE\":\"3176\",\"INFID\":\"F9D46DBF812C4F308670693F6431F498\",\"结算编号\":null,\"病人姓名\":\"宋梅\",\"医生姓名\":\"王伟\",\"身份证\":null,\"科室名称\":\"门诊\",\"发票号\":\"202101170012\",\"门诊号\":\"555780231000M202101170012\",\"收费日期\":\"2021-01-19 23:21:23\",\"明细总额\":4,\"经办人\":\"医保接口\"}";
            var dataValue = JsonConvert.DeserializeObject<OutpatientPersonBaseJsonDto>(ddd);

            //var ddd= CommonHelp.GetValue("WebServiceUrl");
            StringBuilder ctrXml = new StringBuilder();
            ctrXml.Append("<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>");
            ctrXml.Append(@"<ROW>
                        <PO_AKC600>1013441659</PO_AKC600>
	                    <PO_AAE241>216.91</PO_AAE241>
	                    <PO_AAE240>219.7</PO_AAE240>
	                    <PO_XJZF>0.0</PO_XJZF>
	                    <PO_YAZ725>2.31</PO_YAZ725>
	                    <PO_YEZF>0.99</PO_YEZF>
	                    <PO_FHZ>1</PO_FHZ>
	                    <PO_MSG></PO_MSG>
	                    <PO_BXJE>3.30</PO_BXJE>
	                    <PO_BXBL>0.7</PO_BXBL>
                    </ROW>");
              var iniData = XmlSerializeHelper.DESerializer<ResidentOutpatientPreSettlementXmlDto>(ctrXml.ToString());
            //var dataList = _hospitalLogMap.GetList();
            //var ccc= _hospitalLogMap._db.Ado.GetDataTable("select * from table");
            //_hospitalLogMap.CurrentDb.DeleteById(1);
            //_sqlSugarRepository.QueryHospitalLog();
        }
        /// <summary>
        /// 取消对码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void CancelPairCode()
        {
            var ddd = hisSqlRepository.MedicalExpenseMonthReport(new MedicalExpenseMonthReportParam()
            {
                Date = "2021-01",
                OrganizationCode = "10ADC4A48AB743A2B532AD8D08C4B927"
            });
            StringBuilder ctrXml = new StringBuilder();
            ctrXml.Append("<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>");
            ctrXml.Append("<control>");
            ctrXml.Append($"<yab003>{""}</yab003>");//医保经办机构（清算分中心）
            ctrXml.Append($"<ykb053>{""}</ykb053>");//医院清算申请流水号
            ctrXml.Append("</control>");
          
            //
            //_hospitalLogMap.CurrentDb.DeleteById(1);
            //_sqlSugarRepository.QueryHospitalLog();

            var userBase = webServiceBasicService.GetUserBaseInfo("76EDB472F6E544FD8DC8D354BB088BD7");
            //var uploadDataRow = sendList.Select(c => new ThreeCataloguePairCodeUploadRowDto()
            //{
            //    //ProjectId = c.Id.ToString("N"),
            //    HisDirectoryCode = c.DirectoryCode,
            //    //Manufacturer = "",
            //    //ProjectName = c.ProjectName,
            //    //ProjectCode = c.ProjectCode,
            //    //ProjectCodeType = c.DirectoryCategoryCode,
            //    //ProjectCodeTypeDetail = ((ProjectCodeType)Convert.ToInt32(c.ProjectCodeType)).ToString(),
            //    //Remark = c.Remark,
            //    //ProjectLevel = ((ProjectLevel)Convert.ToInt32(c.ProjectLevel)).ToString(),
            //    //RestrictionSign = GetStrData(c.ProjectCodeType, c.RestrictionSign)

            //}).ToList();

            var uploadDataRow = new List<ThreeCataloguePairCodeUploadRowDto>();
            uploadDataRow.Add(new ThreeCataloguePairCodeUploadRowDto
            {
                 HisDirectoryCode = "72F98D9AA80A4933BA269F1A7C970864",
                ProjectName = "厚朴",
                ProjectCode = "8690000-Y-H022",
                ProjectCodeType = "0",
            });

            var  uploadData = new ThreeCataloguePairCodeUploadDto()
            {
                AuthCode = userBase.AuthCode,
                CanCelState = "1",
                UserName = userBase.UserName,
                OrganizationCode = userBase.OrganizationCode,
                PairCodeRow = uploadDataRow,
                VersionNumber = ""
            };
          //  webServiceBasic.HIS_Interface("35", JsonConvert.SerializeObject(uploadData));
        }

   
    }
}
