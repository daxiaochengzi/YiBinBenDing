using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
   public class MedicalExpenseMonthReportParam: PaginationWebParam
    {   /// <summary>
    /// 日期
    /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName { get; set; }
        public string UserId { get; set; }
    }
}
