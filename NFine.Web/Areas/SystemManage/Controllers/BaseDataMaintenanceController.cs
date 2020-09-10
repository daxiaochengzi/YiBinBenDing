using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Params.Web;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces;
using NFine.Application.BenDingManage;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Params;

namespace NFine.Web.Areas.SystemManage.Controllers
{/// <summary>
/// 基层数据维护
/// </summary>
    public class BaseDataMaintenanceController : ControllerBase
    {
        private UserApp userApp = new UserApp();

        private readonly IWebServiceBasicService _webServiceBasicService;
        private readonly IHisSqlRepository _hisSqlRepository; 

        /// <summary>
        /// 
        /// </summary>
        public BaseDataMaintenanceController()
        {
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
            _hisSqlRepository = Bootstrapper.UnityIOC.Resolve<IHisSqlRepository>();
        }
        // GET: SystemManage/BaseDataMaintenance
    
        //重载
        public override ActionResult Index()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            ViewBag.empid = user.F_HisUserId;
            ViewBag.OrganizationCode = userBase.OrganizationCode;
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(QueryPatientInfoParam pagination)
        {
         
            var patientInfo = _hisSqlRepository.QueryPatientInfo(pagination);
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