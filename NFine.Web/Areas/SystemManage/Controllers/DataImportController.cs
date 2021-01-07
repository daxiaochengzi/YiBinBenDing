using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.Params.Web;
using BenDing.Service.Interfaces;
using NFine.Application.SystemManage; 
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class DataImportController :  ControllerBase
    {
        private UserApp userApp = new UserApp();
        private readonly IWebServiceBasicService _webServiceBasicService;

        public DataImportController()
        {
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
        }

        // GET: SystemManage/DataImport
        public ActionResult ImportExcelIcd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImportExcel()
        {
            //var loginInfo = OperatorProvider.Provider.GetCurrent();
            //var user = userApp.GetForm(loginInfo.UserId);
            //if (user.F_IsHisAccount == false) throw new Exception("非基层认证人员不能下载icd10");
            string name = Request.Form["sheetName"];
            HttpPostedFileBase file = Request.Files["file"];
            string content = "";
            if (string.IsNullOrWhiteSpace(name))
            {
                content = "<script>alert('表单元名称不能为空!!!')</script>";
            }
            else
            {
                if (file.ContentLength > 0)
                {
                    var isxls = System.IO.Path.GetExtension(file.FileName)?.ToString().ToLower();
                    if (isxls != ".xls" && isxls != ".xlsx")
                    {
                        Content("请上传Excel文件");
                    }
                    var fileName = file.FileName;//获取文件夹名称
                    var path = Server.MapPath("~/FileExcel/" + fileName);
                    file.SaveAs(path);
                    var dataExcel = ExcelHelper.ExcelToDataTable(path, name, true);
                    if (dataExcel.Columns.Count == 0)
                    {
                        content = "<script>alert('导入的数据不能为空')</script>";
                    }
                    else
                    {
                        var count = _webServiceBasicService.MedicalInsuranceDownloadIcd10(dataExcel, "4518252ED380446D9D5090E003F6EBFB");
                        content = "<script>alert('+" + count + "数据上传成功!!!')</script>";
                    }


                }
            }
            return Content(content);

        }
        [HttpPost]
        public ActionResult BaseDownload()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (user.F_IsHisAccount==false) throw new Exception("非基层认证人员不能下载icd10");
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            var data = _webServiceBasicService.GetIcd10(userBase, new CatalogParam()
            {
                OrganizationCode = userBase.OrganizationCode,
                AuthCode = userBase.AuthCode,
                Nums = 1000,

            });
           
            return Success(data);
        }
        /// <summary>
        /// 更新基层信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateBaseDirectory(string directoryType)
        {
            string resultData = "";
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (user.F_IsHisAccount == false) throw new Exception("非基层认证人员不能更新基层目录");


            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);

            if (userBase != null)
            {
                var inputInpatientInfo = new CatalogParam()
                {
                    AuthCode = userBase.AuthCode,
                    CatalogType = (CatalogTypeEnum)Convert.ToInt16(directoryType),
                    OrganizationCode = userBase.OrganizationCode,
                    Nums = 1000,
                };
                resultData = _webServiceBasicService.GetCatalog(userBase, inputInpatientInfo);

            }

            return Success(resultData);

        }
        public ActionResult DrugCatalogExcel()
        {
            return View();
        }
        /// <summary>
        /// 药品目录导入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportDrugCatalogExcel()
        {
            //var loginInfo = OperatorProvider.Provider.GetCurrent();
            //var user = userApp.GetForm(loginInfo.UserId);
            //if (user.F_IsHisAccount == false) throw new Exception("非基层认证人员不能导入医保项目");
            string name = Request.Form["sheetName"];
            HttpPostedFileBase file = Request.Files["file"];
            string content = "";
            if (string.IsNullOrWhiteSpace(name))
            {
                content = "<script>alert('表单元名称不能为空!!!')</script>";
            }
            else
            {
                if (file.ContentLength > 0)
                {
                    var isxls = System.IO.Path.GetExtension(file.FileName)?.ToString().ToLower();
                    if (isxls != ".xls" && isxls != ".xlsx")
                    {
                        Content("请上传Excel文件");
                    }
                    var fileName = file.FileName;//获取文件夹名称
                    var path = Server.MapPath("~/FileExcel/" + fileName);
                    file.SaveAs(path);
                    var dataExcel = ExcelHelper.ExcelToDataTable(path, name, true);
                    if (dataExcel == null)
                    {
                        content = "<script>alert('数据表格为空')</script>";
                       
                    }
                    else
                    {
                        if (dataExcel.Columns.Count == 0)
                        {
                            content = "<script>alert('导入的数据不能为空')</script>";
                        }
                        else
                        {
                            var count = _webServiceBasicService.DrugCatalogImportExcel(dataExcel, "76EDB472F6E544FD8DC8D354BB088BD7");
                            content = "<script>alert('+" + count + "数据上传成功!!!')</script>";
                        }
                    }

                   


                }
            }
            return Content(content);

        }
        /// <summary>
        /// 下载文件
        /// </summary>
        [HttpGet]
        public HttpResponseMessage DownloadFile()
        {
            //< a href = "http://localhost:51170/api/File/DownloadFile" > 下载模板 </ a >
             string fileName = "报表模板.xlsx";
            string filePath = Server.MapPath("/");
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
            return response;
        }


    }
}