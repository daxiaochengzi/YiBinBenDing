using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.DifferentPlacesXml.CancleHospitalizationSettlement
{
    [XmlRoot("ROW", IsNullable = false)]
   public class YdOutputCancelHospitalizationSettlementXml
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("po_jylsh", IsNullable = false)]
        public string TransactionSerialNumber { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("po_jbsj", IsNullable = false)]
        public string OperationTime { get; set; }
        
    }
}
