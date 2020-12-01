using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Entitys;
using BenDing.Domain.Models.Params.UI.DifferentPlaces;
using BenDing.Repository.Providers.Web;

namespace BenDing.Repository.EntityMap
{
  public  class HospitalizationFeeMap: DbContextBase<HospitalizationFee>
    {
      //  Dictionary<int, List<QueryHospitalizationFeeDto>>
        public Dictionary<int, List<HospitalizationFee>> DoctorAdvicePageList(DoctorAdvicePageUiParam param)
        {
            var resultData = new Dictionary<int, List<HospitalizationFee>>();
            string sqlStr = $"select * from HospitalizationFee where [HospitalizationId]='{param.BusinessId}' and IsDelete=0 ";
            sqlStr += param.DoctorAdviceUploadMark == null
                ? " and DoctorAdviceUploadMark is NULL"
                : " and DoctorAdviceUploadMark = 1";

            int total = 0;
            var list = _db.SqlQueryable<HospitalizationFee>(sqlStr).ToPageList(param.Page, param.Limit, ref total);

            resultData.Add(total, list);

            return resultData;
        }

        public void DoctorAdviceUpload()
        {
        }
    }
}
