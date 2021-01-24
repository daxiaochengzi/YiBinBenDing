﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public  class MedicalExpenseReportExcelDto
    {
        public string 机构 { get; set; }
        public  string 病人姓名 { get; set; }
        public  string 身份证号 { get; set; } 
        public  string 诊断 { get; set; }
        public  string 联系电话 { get; set; }
        public  string 经办人 { get; set; }
        public  DateTime 就诊日期 { get; set; }
        public decimal 合计金额 { get; set; }
        public  decimal 报销金额 { get; set; }
        public decimal 历年结转 { get; set; }
        public  int 标记 { get; set; }
        public  string 报销日期 { get; set; }
        public  string 参保地 { get; set; }
    }
}
