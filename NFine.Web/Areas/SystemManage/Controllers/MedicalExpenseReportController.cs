using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.OutpatientDepartment;
using BenDing.Domain.Models.Params.Web;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class MedicalExpenseReportController :  ControllerBase
    {
        private readonly IHisSqlRepository _hisSqlRepository;
        private UserApp userApp = new UserApp();

        private readonly IWebServiceBasicService _webServiceBasicService;
        /// <summary>
        /// 
        /// </summary>
        public MedicalExpenseReportController()
        {
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
            _hisSqlRepository = Bootstrapper.UnityIOC.Resolve<IHisSqlRepository>();
        }
        //重载
        public override ActionResult Index()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            if (!string.IsNullOrWhiteSpace(user.F_HisUserId))
            {
                var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
                ViewBag.empid = user.F_HisUserId;
                ViewBag.OrganizationCode = userBase.OrganizationCode;
            }

           
            return View();
        }
        /// <summary>
        /// 门诊居民月报表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
    
        public  ActionResult MedicalExpenseMonthReport()
        {
            ViewBag.startTime = DateTime.Now.ToString("yyyy-MM");

            return View();
        }
        /// <summary>
        /// 门诊居民年报表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
      

        public ActionResult MedicalExpenseYearReport()
        {
            ViewBag.startTime = DateTime.Now.ToString("yyyy");

            return View();
        }
        [HttpGet]
     
        public  ActionResult DetailInfo( string patientId)
        {
            ViewBag.PatientId = patientId;
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(MedicalExpenseReportParam pagination)
        {
            if (string.IsNullOrWhiteSpace(pagination.OrganizationCode))
            {
                var loginInfo = OperatorProvider.Provider.GetCurrent();
                var user = userApp.GetForm(loginInfo.UserId);
                if (!string.IsNullOrWhiteSpace(user.F_HisUserId))
                {
                    var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
                    pagination.OrganizationCode = userBase.OrganizationCode;
                }
            }

            var patientInfo = _hisSqlRepository.MedicalExpenseReport(pagination);
            pagination.records = patientInfo.Keys.FirstOrDefault();
            var data = new
            {
                rows = patientInfo.Values.FirstOrDefault(),
                total = pagination.total,
                page = pagination.Page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        /// <summary>
        /// 门诊月统计
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGridYearJson(MedicalExpenseYearReportParam pagination)
        {


            var patientInfo = _hisSqlRepository.MedicalExpenseYearReport(pagination);
            pagination.records = patientInfo.Keys.FirstOrDefault();
            var data = new
            {
                rows = patientInfo.Values.FirstOrDefault(),
                total = pagination.total,
                page = pagination.Page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        /// <summary>
        /// 门诊月统计
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGridMonthJson(MedicalExpenseMonthReportParam pagination)
        {


            var patientInfo = _hisSqlRepository.MedicalExpenseMonthReport(pagination);
            pagination.records = patientInfo.Keys.FirstOrDefault();
            var data = new
            {
                rows = patientInfo.Values.FirstOrDefault(),
                total = pagination.total,
                page = pagination.Page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetGridDetailJson(QueryOutpatientDetailParam pagination)
        {
          

            var patientInfo = _hisSqlRepository.QueryOutpatientDetail(pagination);
            pagination.records = patientInfo.Keys.FirstOrDefault();
            var data = new
            {
                rows = patientInfo.Values.FirstOrDefault(),
                total = pagination.total,
                page = pagination.Page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
    }
}