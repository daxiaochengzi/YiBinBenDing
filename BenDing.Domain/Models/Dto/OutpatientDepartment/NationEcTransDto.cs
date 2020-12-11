using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BenDing.Domain.Models.Dto.Web;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{


    [XmlRoot("ROW", IsNullable = false)]
    public class NationEcTransDto : IniDto
    {/// <summary>
     /// 电子凭证记录号
     /// </summary>
        [JsonProperty(PropertyName = "MERCHANTSN")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 账户支付流水号
        /// </summary>
        [JsonProperty(PropertyName = "PO_HKLSH")]
        public string AccountPaySerialNumber { get; set; }


        /// <summary>
        /// 账户支金额
        /// </summary>
        [JsonProperty(PropertyName = "PO_ZHZFJE")]
        public decimal AccountPayAmount { get; set; }

        /// <summary>
        /// 自付金额
        /// </summary>
        [JsonProperty(PropertyName = "PO_ZFZFJE")]
        public decimal SelfPayAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "PO_AAE240")]
        public decimal BalanceAmount { get; set; }
    }
}
