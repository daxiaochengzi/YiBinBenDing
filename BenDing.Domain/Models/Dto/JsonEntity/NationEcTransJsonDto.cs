using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.JsonEntity
{
   public class NationEcTransJsonDto
    {
        /// <summary>
        /// 账户支金额
        /// </summary>
        [JsonProperty(PropertyName = "账户支金额")]
        public decimal AccountPayAmount { get; set; }

        /// <summary>
        /// 自付金额
        /// </summary>
        [JsonProperty(PropertyName = "自付金额")]
        public decimal SelfPayAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "账户余额")]
        public decimal BalanceAmount { get; set; }
    }
}
