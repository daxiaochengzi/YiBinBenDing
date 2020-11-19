using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Dto.DifferentPlaces
{
    [XmlRoot("ROW", IsNullable = false)]
    public class TestXml
    {/// <summary>
        /// 接口返回值
        /// </summary>

        [XmlElement("po_fhz", IsNullable = false)]

        public string InterfaceStatus { get; set; }

        /// <summary>
        /// 接口返回信息
        /// </summary>
        [XmlElement("po_msg", IsNullable = false)]

        public string InterfaceMsg { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("po_jylsh", IsNullable = false)]
        public string TransactionSerialNumber { get; set; }
        /// <summary>
        /// 个人账户支付
        /// </summary>
        [XmlElement("akb066", IsNullable = false)]
        public decimal AccountPayAmount { get; set; }
    }
}
