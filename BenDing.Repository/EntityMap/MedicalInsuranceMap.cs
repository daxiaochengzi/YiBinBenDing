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

    
        public void InsertData(MedicalInsurance medicalInsurance, UserInfoDto user)
        {
            medicalInsurance.IniCreate(user);
            _db.Insertable(medicalInsurance);
        }
        /// <summary>
        /// 更新社保状态
        /// </summary>
        /// <param name="medicalInsurance"></param>
       
        public void UpdateState(MedicalInsurance medicalInsurance)
        {
            _db.Updateable(medicalInsurance).UpdateColumns(it => new { it.MedicalInsuranceState }).WhereColumns(it => new { it.Id });
           
        }
        //public void Insert(MedicalInsurance medicalInsurance, UserInfoDto user)
        //{
        //    medicalInsurance.Create(user);
        //    _db.Insertable(medicalInsurance);
        //}

    }
}
