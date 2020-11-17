using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces
{/// <summary>
/// 异地门诊预结算回参
/// </summary>
   public class YdOutpatientPreSettlementJsonDto
    {  /// <summary>
        /// 接口返回值
        /// </summary>
        [JsonProperty(PropertyName = "po_fhz")]

        public string InterfaceStatus { get; set; }

        /// <summary>
        /// 接口返回信息
        /// </summary>
        [JsonProperty(PropertyName = "po_msg")]

        public string InterfaceMsg { get; set; }

    }
}
