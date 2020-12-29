using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
    [XmlRoot("ROW", IsNullable = false)]
    public class ResidentOutpatientPreSettlementXmlDto
    {
       
        /// <summary>
        /// 就诊流水号
        /// </summary>
        
        [XmlElementAttribute("PO_AKC600", IsNullable = false)]

        public string SettlementNo { get; set; }
        /// <summary>
        /// 门诊报销金额
        /// </summary>
     
        [XmlElementAttribute("PO_BXJE", IsNullable = false)]
        public decimal ReimbursementAmount { get; set; }
        /// <summary>
        /// 统筹支付金额
        /// </summary>
       
        [XmlElementAttribute("PO_YAZ725", IsNullable = false)]
        public decimal OverallPlanningPayAmount { get; set; }
        /// <summary>
        /// 余额支付
        /// </summary>
      
        [XmlElementAttribute("PO_YEZF", IsNullable = false)]
        public decimal BalancePaymentAmount { get; set; }
        /// <summary>
        /// 余额支付
        /// </summary>
       
        [XmlElementAttribute("PO_XJZF", IsNullable = false)]
        public decimal CashPaymentAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
       
        [XmlElementAttribute("PO_AAE240", IsNullable = false)]
        public decimal BalanceAmount { get; set; }
        /// <summary>
        /// 门诊转结余额
        /// </summary>
     
        [XmlElementAttribute("PO_AAE241", IsNullable = false)]
        public decimal TurnSettlementBalanceAmount { get; set; }
        /// <summary>
        /// 报销比例
        /// </summary>
        [XmlElementAttribute("PO_BXBL", IsNullable = false)]
        public decimal ReimbursementRatio { get; set; }
        
    }
}
