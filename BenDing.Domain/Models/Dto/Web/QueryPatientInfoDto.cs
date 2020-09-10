using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Web
{
   public class QueryPatientInfoDto
    {
        public  string Id { get; set; }
        /// <summary>
        /// 门诊号或者住院号
        /// </summary>
        public string NumCode { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public  string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public  string MedicalInsuranceState { get; set; }
        /// <summary>
        /// 产生时间
        /// </summary>
        public  string CreateTime { get; set; }
    }
}
