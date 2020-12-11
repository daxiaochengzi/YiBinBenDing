using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.JsonEntity
{
   public class OutpatientNationEcTransResidentJsonDto
    {
        /// <summary>
        /// 就诊流水号
        /// </summary>
        [JsonProperty(PropertyName = "PO_AKC600")]
       
        public string SettlementNo { get; set; }
        /// <summary>
        /// 门诊报销金额
        /// </summary>
        [JsonProperty(PropertyName = "PO_BXJE")]
        public decimal ReimbursementAmount { get; set; }
        /// <summary>
        /// 统筹支付金额
        /// </summary>
        [JsonProperty(PropertyName = "PO_YAZ725")]
        public decimal OverallPlanningPayAmount { get; set; }
        /// <summary>
        /// 余额支付
        /// </summary>
        [JsonProperty(PropertyName = "PO_YEZF")]
        public decimal BalancePaymentAmount { get; set; }
        /// <summary>
        /// 余额支付
        /// </summary>
        [JsonProperty(PropertyName = "PO_XJZF")]
        public decimal CashPaymentAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "PO_AAE240")]
        public decimal BalanceAmount { get; set; }
        /// <summary>
        /// 门诊转结余额
        /// </summary>
        [JsonProperty(PropertyName = "PO_AAE241")]
        public decimal TurnSettlementBalanceAmount { get; set; }
        
    }
}
