using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.Web
{
   public class QueryPatientInfoParam: PaginationWebParam
    {
       
        /// <summary>
        /// 开始时间
        /// </summary>
        public  string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 是否门诊病人
        /// </summary>
        public string IsOutpatient { get; set; } = "0";
    }
}
