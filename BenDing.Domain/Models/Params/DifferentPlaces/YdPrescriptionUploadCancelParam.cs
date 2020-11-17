using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.DifferentPlaces
{/// <summary>
 /// 异地处方上传取消
 /// </summary>
    [XmlRoot("ROW", IsNullable = false)]
    public class YdPrescriptionUploadCancelParam
    {/// <summary>
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
        /// 参保地统筹区代码
        /// </summary>
        [XmlElement("baa008", IsNullable = false)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElement("bkc131", IsNullable = false)]
        public string Operators { get; set; }
        /// <summary>
        /// 处方号 len(20)
        /// </summary>
        [XmlElementAttribute("aae072", IsNullable = false)]
        public string PrescriptionNum { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlElement("cfxh", IsNullable = false)]
        public YdPrescriptionUploadCancelRowListParam DetailList { get; set; }
        /// <summary>
        /// 开处方日期 (yyyy-mm-dd)
        /// </summary>
        [XmlElementAttribute("bkc040", IsNullable = false)]
        public string DirectoryDate { get; set; }

    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdPrescriptionUploadCancelRowListParam
    {/// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("datarow")]
        [XmlArrayItem("ROW")]
        public List<YdPrescriptionUploadCancelRowParam> RowDataList { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdPrescriptionUploadCancelRowParam
    {
        /// <summary>
        ///  处方序号（在医疗机构系统中产生的费用序号，一次就诊的序号不能重复）
        /// </summary>
        [XmlElementAttribute("bke019", IsNullable = false)]
        public int PrescriptionSort { get; set; }
    }
   
}
