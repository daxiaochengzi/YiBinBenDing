using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
   public class MedicalExpenseMonthReportParam
    {   /// <summary>
    /// 日期
    /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string OrganizationCode { get; set; }
    }
}
