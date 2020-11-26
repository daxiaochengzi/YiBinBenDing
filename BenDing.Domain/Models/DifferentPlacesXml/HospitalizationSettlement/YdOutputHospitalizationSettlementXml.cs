using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationPreSettlement;

namespace BenDing.Domain.Models.DifferentPlacesXml.HospitalizationSettlement
{
    [XmlRoot("ROW", IsNullable = false)]
    public class YdOutputHospitalizationSettlementXml: YdOutputHospitalizationPreSettlementXml
    {/// <summary>
     /// 清算类别
     /// </summary>

        [XmlElement("bka015", IsNullable = false)]
        public string LiquidationCategory { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("po_jylsh", IsNullable = false)]
        public string TransactionSerialNumber { get; set; }
    }
}
