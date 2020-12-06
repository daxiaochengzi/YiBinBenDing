using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.DifferentPlacesXml.PayCard
{/// <summary>
 /// 异地刷卡回参
 /// </summary>
    [XmlRoot("ROW", IsNullable = false)]
    public  class YdOutpatientPayCardXml
    {/// <summary>
     /// 支付流水号
     /// </summary>
        [XmlElement("po_hklsh", IsNullable = false)]
        public string SerialNumber { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>

        [XmlElement("po_zfzfje", IsNullable = false)]
        public decimal CashPayAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>

        [XmlElement("po_zhzfje", IsNullable = false)]
        public decimal AccountPayAmount { get; set; }
    }
}
