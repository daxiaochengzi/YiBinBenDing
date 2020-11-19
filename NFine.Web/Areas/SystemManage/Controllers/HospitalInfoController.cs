using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BenDing.Domain.Models.Entitys;
using NFine.Application.SystemManage;

namespace NFine.Web.Areas.SystemManage.Controllers
{/// <summary>
/// 医院信息
/// </summary>
    public class HospitalInfoController : ControllerBase
    {
        private UserApp userApp = new UserApp();
        private HospitalGeneralCatalog hospitalGeneralCatalogMap = new HospitalGeneralCatalog();

        //// GET: SystemManage/HospitalInfo
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}