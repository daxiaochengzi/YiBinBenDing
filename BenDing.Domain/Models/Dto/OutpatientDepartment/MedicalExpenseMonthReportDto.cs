using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
  public  class MedicalExpenseMonthReportDto
    {  /// <summary>
    /// 天
    /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// 次数
        /// </summary>
        public  int Frequency { get; set; }
        /// <summary>
        /// 门诊费用
        /// </summary>
        public  decimal MedicalTreatmentTotalCost { get; set; }
        /// <summary>
        /// 报销合计
        /// </summary>
        public decimal ReimbursementExpensesAmount { get; set; }
    }
}
