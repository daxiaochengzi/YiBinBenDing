using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class WorkerHospitalSettlementCardBackDto
    {   /// <summary>
        /// 流水号
        /// </summary>
        
        [JsonIgnore]
        public string SerialNumber { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
        [JsonProperty(PropertyName = "账户支付")]
        public decimal AccountPayment { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        [JsonProperty(PropertyName = "现金支付")]
        public decimal CashPayment { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "账户余额")]
        public decimal AccountBalance { get; set; }
    }
}
