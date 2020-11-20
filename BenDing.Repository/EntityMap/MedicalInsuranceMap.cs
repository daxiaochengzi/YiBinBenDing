using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Entitys;
using BenDing.Repository.Providers.Web;

namespace BenDing.Repository.EntityMap
{
    public class MedicalInsuranceMap : DbContextBase<MedicalInsurance>
    {

        public MedicalInsurance QueryFirstEntity(string businessId)
        {
            var resultData = _db.SqlQueryable<MedicalInsurance>("select * from MedicalInsurance").Where(it =>
                it.BusinessId == businessId &&
                it.IsDelete == false
            ).First();
            return resultData;
        }
        public void Insert(MedicalInsurance medicalInsurance, UserInfoDto user)
        {
            medicalInsurance.Create(user);
            _db.Insertable(medicalInsurance);
        }
       

    }
}
