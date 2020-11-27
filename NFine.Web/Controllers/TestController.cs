using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BenDing.Domain.Models.DifferentPlacesXml.DoctorOrderUpload;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationRegister;
using BenDing.Domain.Models.Dto;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Dto.DifferentPlaces;
using BenDing.Domain.Models.Dto.JsonEntity;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Entitys;
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
                var param = new YdHospitalizationRegisterParam()
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
        public ApiJsonResultData GetUserInfo([FromBody] UiInIParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);

                y.Data = userBase;

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
                    SettlementNo = ""
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
                var liquSubCenter = "123";
                var applicationSerialNumber = "123";
                //基卫操作员登录验证
                StringBuilder ctrXml = new StringBuilder();
                ctrXml.Append("<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>");
                ctrXml.Append("<control>");
                ctrXml.Append($"<yab003>{liquSubCenter}</yab003>");//医保经办机构（清算分中心）
                ctrXml.Append($"<ykb053>{applicationSerialNumber}</ykb053>");//医院清算申请流水号
                ctrXml.Append("</control>");





                string xmlStr = @"<?xml version='1.0' encoding='utf-8'?>
                                <ROW>
                                  <po_fhz>1</po_fhz>
                                  <po_msg>123</po_msg>
                                </ROW>";
                var xmlData = XmlSerializeHelper.DESerializer<TestXml>(xmlStr);
                var settlementJson = "{\"SerialNumber\": \"101080551392\", 	\"AccountPayment\": 0.03, 	\"CashPayment\": 0.0, 	\"AccountBalance\": 386.7 }";
                var iniData = JsonConvert.DeserializeObject<WorkerHospitalSettlementCardBackDataDto>(settlementJson);
                //var data = XmlHelp.DeSerializerModel(new BenDing.Domain.Models.Dto.OutpatientDepartment.QueryOutpatientDepartmentCostDto(), true);
                //if (data == null) throw new Exception("门诊费用查询出错");
                //var cc = AutoMapper.Mapper.Map<QueryOutpatientDepartmentCostjsonDto>(data);
                //var ddd = new List<InpatientDiagnosisDto>();






                //var ddd = new List<InpatientDiagnosisDto>();

                //ddd.Add(new InpatientDiagnosisDto()
                //{
                //    IsMainDiagnosis = false,
                //    ProjectCode = "1假体植入",
                //    DiseaseName = "1"
                //});
                //ddd.Add(new InpatientDiagnosisDto()
                //{
                //    IsMainDiagnosis = false,
                //    ProjectCode = "2膝关节假体植入",
                //    DiseaseName = "2"
                //});
                //ddd.Add(new InpatientDiagnosisDto()
                //{
                //    IsMainDiagnosis = true,
                //    ProjectCode = "3膝关节假体植入",
                //    DiseaseName = "3"
                //});
                //ddd.Add(new InpatientDiagnosisDto()
                //{
                //    IsMainDiagnosis = false,
                //    ProjectCode = "4膝关节假体植入",
                //    DiseaseName = "4"
                //});
                //var dds = CommonHelp.LeaveHospitalDiagnosis(ddd);
                //        y.Data = dds;
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
              


            });
        }

        /// <summary>
        /// 医院三大目录批量上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiJsonResultData HospitalThreeCatalogBatchUpload([FromBody] UiInIParam param)
        {
            return new ApiJsonResultData(ModelState, new UiInIParam()).RunWithTry(y =>
            {
                var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);

                var paramIni = new MedicalInsurancePairCodesUiParam();

                if (userBase != null && string.IsNullOrWhiteSpace(userBase.OrganizationCode) == false)
                {
                    paramIni.OrganizationCode = userBase.OrganizationCode;
                    paramIni.OrganizationName = userBase.OrganizationName;

                    webServiceBasicService.ThreeCataloguePairCodeUpload(
                        new UpdateThreeCataloguePairCodeUploadParam()
                        {
                            User = userBase,
                            ProjectCodeList = new List<string>()
                        }
                    );

                }

                ImedicalInsuranceSqlRepository.HospitalThreeCatalogBatchUpload(userBase);

            });

        }

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
                var queryData = hisSqlRepository.QueryAllICD10();

                if (queryData.Any())
                {
                    dataList = queryData.Select(d => new Icd10PairCodeDataParam
                    {
                        DiseaseId = d.DiseaseId,
                        ProjectCode = d.DiseaseCoding,
                        ProjectName = d.DiseaseName
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

                        webServiceBasicService.Icd10PairCode(new Icd10PairCodeParam()
                        {
                            DataList = sendList,
                            User = userBase,
                            BusinessId = "00000000000000000000000000000000"
                        });
                        //更新数据上传状态
                        idList.AddRange(sendList.Select(d => d.DiseaseId).ToList());
                        a++;

                    }
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
                //回参构建
                var xmlData = new OutpatientDepartmentCostCancelXml()
                {
                    SettlementNo = "54901231"
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
                //_outpatientDepartmentNewService.CancelOutpatientDepartmentCost(param);
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
    
            var dataList = _hospitalLogMap.GetList();
             var ccc= _hospitalLogMap._db.Ado.GetDataTable("select * from table");
            //_hospitalLogMap.CurrentDb.DeleteById(1);
            //_sqlSugarRepository.QueryHospitalLog();
        }

        /// <summary>
        /// 获取基层信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void GetBaseData([FromUri]UiBaseDataParam param)
        {
            var userBase = webServiceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var xmlData = new MedicalInsuranceXmlDto();
            xmlData.BusinessId = param.BusinessId;
            xmlData.HealthInsuranceNo = "34";
            xmlData.TransactionId = userBase.TransKey;
            xmlData.AuthCode = userBase.AuthCode;
            xmlData.UserId = userBase.UserId;
            xmlData.OrganizationCode = userBase.OrganizationCode;
            var jsonParam = JsonConvert.SerializeObject(xmlData);
            var data = webServiceBasic.HIS_Interface("39", jsonParam);
            var baseOutput = XmlSerializeHelper.YdDeSerializer<YdBaseOutputDoctorOrderUploadXml>(data.Msg.ToString());

            // var baseOutput=  XmlHelp.DeSerializer<YdBaseOutputDoctorOrderUploadXml>(data.Msg.ToString());
        }
    }
}
