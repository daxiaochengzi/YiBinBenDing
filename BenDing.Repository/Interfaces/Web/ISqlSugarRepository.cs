using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Entitys;

namespace BenDing.Repository.Interfaces.Web
{

  public  interface ISqlSugarRepository
    {
        void QueryHospitalLog();
        /// <summary>
        /// ICD10批量上传
        /// </summary>
        /// <returns></returns>
        List<ICD10PairCode> QueryICD10PairCode();
    }
}
