using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces
{/// <summary>
/// 异地住院结算
/// </summary>
   public class YdHospitalizationSettlementJsonDto:YdHospitalizationPreSettlementJsonDto
    {
        /// <summary>
        /// 清算类别
        /// </summary>
        [JsonProperty(PropertyName = "bka015")]

        public string SettlementType { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        [JsonProperty(PropertyName = "po_jylsh")]

        public string TransactionSerialNumber { get; set; }
    }
}
