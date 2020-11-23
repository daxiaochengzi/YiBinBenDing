using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.DifferentPlacesXml.HospitalizationRegister
{
    [XmlRoot("ROW", IsNullable = false)]
    public class YdOutputHospitalizationRegisterXml
    {/// <summary>
     /// 个人账户余额
     /// </summary>
       
        [XmlElement("po_grzhye", IsNullable = false)]
        public Decimal AccountBalance { get; set; }
        /// <summary>
        /// 医保住院号
        /// </summary>
      
        [XmlElement("po_zyh", IsNullable = false)]
        public string MedicalInsuranceHospitalizationNo { get; set; }
        /// <summary>
        /// 出生日期 Birthday
        /// </summary>

      
        [XmlElement("po_csrq", IsNullable = false)]
        public string Birthday { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>

      
        [XmlElement("po_gmsfz", IsNullable = false)]
        public string IdCardNo { get; set; }
        /// <summary>
        /// 参保身份
        /// </summary>
      
        [XmlElement("po_cbsf", IsNullable = false)]
        public string InsuredStatus { get; set; }
        /// <summary>
        /// 性别
        /// </summary>

      
        [XmlElement("po_xb", IsNullable = false)]
        public string PatientSex { get; set; }

        /// <summary>
        /// 险种类型310:城镇职工基本医疗保险342：城乡居民基本医疗保险根据获取的险种类型，调用对应的职工或者居民接口办理入院。
        /// </summary>

       
        [XmlElement("po_xzlx", IsNullable = false)]
        public string InsuranceType { get; set; }
        /// <summary>
        /// 特殊人员类别
        /// </summary>
        [XmlElement("po_tsrylb", IsNullable = false)]
     
        public string SpecialPersonnelType { get; set; }
        /// <summary>
        /// 参保人所属行政区域
        /// </summary>

    
        [XmlElement("po_xzqh", IsNullable = false)]
        public string AdministrativeArea { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>

     
        [XmlElement("po_xm", IsNullable = false)]
        
        public string PatientName { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>

      
        [XmlElement("po_dwmc", IsNullable = false)]
        public string CompanyName { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
       
        [XmlElement("po_dwbh", IsNullable = false)]
        public string CompanyCode { get; set; }
        /// <summary>
        /// 享受待遇标识
        /// </summary>
     
        [XmlElement("po_xsdybs", IsNullable = false)]
        public string EnjoySign { get; set; }

        /// <summary>
        /// 未享受待遇原因
        /// </summary>
        [JsonProperty(PropertyName = "po_bxsdyyy")]
        [XmlElement("po_bxsdyyy", IsNullable = false)]
        public string NotEnjoyCause { get; set; }
    }
}
