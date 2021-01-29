using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class MedicalExpenseYearReportDto
    {
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// 月份
        /// </summary>

        public string Month { get; set; }
        /// <summary>
        /// 次数
        /// </summary>
        public  int Frequency { get; set; }
    }
}
