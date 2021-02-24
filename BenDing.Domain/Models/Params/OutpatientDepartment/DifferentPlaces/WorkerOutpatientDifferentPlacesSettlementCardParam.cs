using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.OutpatientDepartment.DifferentPlaces
{
    [XmlRoot("ROW", IsNullable = false)]
    public class WorkerOutpatientDifferentPlacesSettlementCardParam
    {
        /// <summary>
        /// 行政区域
        /// </summary>
        [XmlElementAttribute("pi_xzqh", IsNullable = false)]
        public string AreaCode { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>

        [XmlElementAttribute("pi_fyze", IsNullable = false)]
        public string TotalAmount { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        [XmlElementAttribute("pi_cardid", IsNullable = false)]
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 卡类别 (1门诊 2住院 )
        /// </summary>
        [XmlElementAttribute("pi_cardid", IsNullable = false)]
        public string IcCardType { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("pi_jbr", IsNullable = false)]
        public string OperatorName { get; set; }
        
    }
}
