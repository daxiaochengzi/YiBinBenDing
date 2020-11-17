using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.DifferentPlaces
{
    [XmlRoot("ROW", IsNullable = false)]
    public class YdHospitalizationSettlementParam
    {
        /// <summary>
        /// 参保地统筹区代码
        /// </summary>
        [XmlElement("baa008", IsNullable = false)]
        public string AreaCode { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>


        [XmlElement("aac001", IsNullable = false)]
        public string PersonalCode { get; set; }
        /// <summary>
        /// 就诊记录号
        /// </summary>


        [XmlElement("aaz217", IsNullable = false)]
        public string VisitRecordNumber { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>

        [XmlElement("bkc131", IsNullable = false)]
        public string Operators { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>

        [XmlElement("nums", IsNullable = false)]
        public int Nums { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        [XmlElement("akc264", IsNullable = false)]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 下账金额 不能大于结算后的自付总金额
        /// </summary>
        [XmlElement("bkc142", IsNullable = false)]
        public decimal DownAccountAmount { get; set; }
         
    }
}
