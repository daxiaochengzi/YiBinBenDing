using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class QueryMedicalExpenseMonthReportUiParam: PaginationDto
    {    /// <summary>
        /// 月份
        /// </summary>
        public string MonthDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }
    }
}
