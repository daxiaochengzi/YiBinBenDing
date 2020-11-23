using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.Web;
using BenDing.Repository.EntityMap;
using BenDing.Service.Interfaces;
using NFine.Application.SystemManage;
using NFine.Code;

namespace NFine.Web.Areas.SystemManage.Controllers
{/// <summary>
/// 医院信息
/// </summary>
    public class HospitalInfoController : ControllerBase
    {
        private readonly IWebServiceBasicService _webServiceBasicService;
        private UserApp userApp = new UserApp();
        //private HospitalGeneralCatalogMap hospitalGeneralCatalogMap = new HospitalGeneralCatalogMap();
        /// <summary>
        /// 
        /// </summary>
        public HospitalInfoController()
        {
            _webServiceBasicService = Bootstrapper.UnityIOC.Resolve<IWebServiceBasicService>();
           
        }
        public override ActionResult Index()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            var user = userApp.GetForm(loginInfo.UserId);
            var userBase = _webServiceBasicService.GetUserBaseInfo(user.F_HisUserId);
            ViewBag.empid = user.F_HisUserId;
            ViewBag.OrganizationCode = userBase.OrganizationCode;
            return View();
        }
        //// GET: SystemManage/HospitalInfo
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(HospitalGeneralCatalogUiParam pagination)
        {
          
            //var patientInfo = hospitalGeneralCatalogMap.PageList(pagination);
            //pagination.records = patientInfo.Keys.FirstOrDefault();
            //var data = new
            //{
            //    rows = patientInfo.Values.FirstOrDefault(),
            //    total = pagination.total,
            //    page = pagination.Page,
            //    records = pagination.records
            //};
            return Content("");
        }
    }
}