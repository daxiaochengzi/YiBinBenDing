using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Entitys;
using BenDing.Repository.Providers.Web;

namespace BenDing.Repository.EntityMap
{
   public class InpatientMap: DbContextBase<Inpatient>
    {
        /// <summary>
        /// 更新社保状态
        /// </summary>
        /// <param name="medicalInsurance"></param>

        public void IsCanCelHospitalized(Inpatient medicalInsurance)
        {
            _db.Updateable(medicalInsurance).UpdateColumns(it => new { it.IsCanCelHospitalized }).WhereColumns(it => new { it.Id });

        }
        
    }
}
