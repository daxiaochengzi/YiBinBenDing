using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class MedicalExpenseYearExcelDto
    {
        public string 机构名称 { get; set; }
        public string 汇总月份 { get; set; }
        public int 总汇总人次 { get; set; }
    }
}
