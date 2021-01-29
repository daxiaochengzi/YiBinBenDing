using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
  public  class MedicalExpenseMonthExcelDto
    {
        public string 日期 { get; set; }
        public int 一般诊疗费人次 { get; set; }
        public decimal 门诊费用 { get; set; }
        public decimal 报销金额 { get; set; }
    }
}
