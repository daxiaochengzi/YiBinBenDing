using System.Xml.Serialization;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationPreSettlement;

namespace BenDing.Domain.Models.DifferentPlacesXml.HospitalizationSettlement
{
    [XmlRoot("ROW", IsNullable = false)]

    public class YdInputHospitalizationSettlementXml: YdInputHospitalizationPreSettlementXml
    {
        /// <summary>
        /// 下账金额
        /// </summary>
        [XmlElement("bkc142", IsNullable = false)]
        public decimal DownAmount { get; set; }
    }
}
