using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.JsonEntity
{
   public class OutpatientNationEcTransResidentBackDto
    {
        /// <summary>
        /// 报销金额
        /// </summary>
        [JsonProperty(PropertyName = "报销金额")]
        public decimal ReimbursementAmount { get; set; }
        /// <summary>
        /// 统筹支付金额
        /// </summary>
        [JsonProperty(PropertyName = "统筹支付")]
        public decimal OverallPlanningPayAmount { get; set; }
        /// <summary>
        /// 余额支付
        /// </summary>
        [JsonProperty(PropertyName = "余额支付")]
        public decimal BalancePaymentAmount { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        [JsonProperty(PropertyName = "现金支付")]
        public decimal CashPaymentAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "账户余额")]
        public decimal BalanceAmount { get; set; }
        /// <summary>
        /// 门诊转结余额
        /// </summary>
        [JsonProperty(PropertyName = "门诊转结余额")]
        public decimal TurnSettlementBalanceAmount { get; set; }
    }
}
