using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.DifferentPlacesXml.DoctorOrderUpload
{
    [XmlRoot("input", IsNullable = false)]
    public class YdBaseOutputDoctorOrderUploadXml
    {
        /// <summary>
        /// 组织机构
        /// </summary>
        [XmlElement("his_code", IsNullable = false)]
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        [XmlElement("interface_id", IsNullable = false)]
        public string BusinessId { get; set; }
        /// <summary>
        /// 医嘱号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string DoctorOrder { get; set; }
        /// <summary>
        /// 开单医生
        /// </summary>
        [XmlElement("ykc106", IsNullable = false)]
        public string BillDoctorName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("dataset")]
        [XmlArrayItem("row")]
        public List<YdBaseOutputDoctorOrderUploadRowXml> RowDataList { get; set; }

    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdBaseOutputDoctorOrderUploadRowXml{
        /// <summary>
        /// 医嘱号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string DoctorOrder { get; set; }
        /// <summary>
        /// 目录编码
        /// </summary>
        [XmlElement("bkc127", IsNullable = false)]
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 目录名称
        /// </summary>
        [XmlElement("ake099", IsNullable = false)]
        public string DirectoryName { get; set; }
        
        /// <summary>
        /// 医嘱执行时间
        /// </summary>
        [XmlElement("bkc128", IsNullable = false)]
        public string OperationTime { get; set; }
        /// <summary>
        /// 医嘱执行医生编码
        /// </summary>
        [XmlElement("bkc048", IsNullable = false)]
        public string OperationDoctorCode { get; set; }
        /// <summary>
        /// 医嘱执行医生
        /// </summary>
        [XmlElement("bkc049", IsNullable = false)]
        public string OperationDoctorName { get; set; }
      
    }
}
