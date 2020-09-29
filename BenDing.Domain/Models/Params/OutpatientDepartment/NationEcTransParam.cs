using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
    /// <summary>
    /// 医保凭证支付
    /// </summary>
    [XmlRoot("ROW", IsNullable = false)]
    public class NationEcTransParam
    {
        /// <summary>
        /// 下账金额
        /// </summary>

        [XmlElementAttribute("BKC142", IsNullable = false)]

        public Decimal DownAccountAmount { get; set; }

        /// <summary>
        ///   下载类别 【1 门诊  2住院】
        /// </summary>
        [XmlElementAttribute("HKLB", IsNullable = false)]

        public string DownAccountType { get; set; }

        /// <summary>
        ///   备注说明
        /// </summary>
        [XmlElementAttribute("AAE013", IsNullable = false)]

        public string Remark { get; set; }

        /// <summary>
        ///   费用条数
        /// </summary>
        [XmlElementAttribute("NUMS", IsNullable = false)]

        public int Nums { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("DATAROW")]
        [XmlArrayItem("ROW")]
        public List<NationEcTransRow> RowDataList { get; set; }


    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class NationEcTransRow
    {
        /// <summary>
        /// 序号
        /// </summary>
        [XmlElementAttribute("BKE019", IsNullable = false)]
        public string ColNum { get; set; }
        /// <summary>
        /// 商品条形码 
        /// </summary>
        [XmlElementAttribute("BKE030", IsNullable = false)]
        public string Barcode { get; set; }
        /// <summary>
        /// 医保项目编号
        /// </summary>
        [XmlElementAttribute("AAZ231", IsNullable = false)]
        public string ProjectCode { get; set; }
       
        
        /// <summary>
        /// 院内项目编码
        /// </summary>
        [XmlElementAttribute("BKE026", IsNullable = false)]
        public string DirectoryCode { get; set; }

        /// <summary>
        /// 院内项目名称
        /// </summary>
        [XmlElementAttribute("BKE027", IsNullable = false)]
        public string DirectoryName { get; set; }

        /// <summary>
        /// 单价   (12,4)
        /// </summary>
        [XmlElementAttribute("AKC225", IsNullable = false)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 数量   (12,4)
        /// </summary>
        [XmlElementAttribute("AKC226", IsNullable = false)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 总金额 ((12,4)每条费用明细的数据校验为传入的金额（四舍五入到两位小数）和传入的单价*传入的数量（四舍五入到两位小数）必须相等，检查不等的会提示报错
        /// </summary>
        [XmlElementAttribute("AKC264", IsNullable = false)]
        public decimal TotalAmount { get; set; }


    }
}
