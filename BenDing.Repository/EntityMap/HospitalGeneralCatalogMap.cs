using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Params.Base;
using BenDing.Repository.Providers.Web;

namespace BenDing.Repository.EntityMap
{
   public class HospitalGeneralCatalogMap:DbContextBase<HospitalGeneralCatalog>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Dictionary<int, List<HospitalGeneralCatalog>> PageList(PaginationWebParam param)
        {
            int total = 0;
            var resultData = new Dictionary<int, List<HospitalGeneralCatalog>>();
            var list = _db.SqlQueryable<HospitalGeneralCatalog>("select * from HospitalGeneralCatalog").Where(it => it.DirectoryType == param.KeyWord && it.OrganizationCode== param.OrganizationCode).ToPageList(param.Page, param.rows, ref total);
            resultData.Add(total, list);
            return resultData;
        }
    }
}
