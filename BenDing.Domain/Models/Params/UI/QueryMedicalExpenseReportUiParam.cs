using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class QueryMedicalExpenseReportUiParam: PaginationDto
    {/// <summary>
        /// 病人名称
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
      /// <summary>
      /// 
      /// </summary>
        public string UserId { get; set; }
    }
}
