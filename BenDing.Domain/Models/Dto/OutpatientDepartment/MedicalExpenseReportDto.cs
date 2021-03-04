using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class MedicalExpenseReportDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 病人id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 组织机构名称
        /// </summary>
        public  string OrganizationName { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>

        public  string IdCardNo { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>

        public string Operator { get; set; }
        /// <summary>
        /// 就诊时间
        /// </summary>
        public  DateTime VisitDate { get; set; }
        /// <summary>
        /// 参保地
        /// </summary>

        public  string CommunityName { get; set; }
        /// <summary>
        /// 结算人员
        /// </summary>
        public  string SettlementUserName { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>

        public DateTime SettlementTime { get; set; }

        /// <summary>
        /// 合计金额
        /// </summary>
        public  decimal MedicalTreatmentTotalCost { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public  string ContactAddress { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 门诊转结
        /// </summary>
        public decimal CarryOver { get; set; }
        /// <summary>
        /// 报销金额
        /// </summary>
        public decimal ReimbursementExpensesAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string DiagnosticJson { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public int Sign { get; set; }
    }
}
