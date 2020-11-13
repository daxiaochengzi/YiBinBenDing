using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.Resident
{
    [XmlRootAttribute("ROW", IsNullable = false)]
    public  class YdPrescriptionUploadsParam
    {   /// <summary>
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
        ///数量
        /// </summary>
        [XmlElement("nums", IsNullable = false)]
        public string nums { get; set; }
        
        /// <summary>
        ///  
        /// </summary>
        [XmlElement("CFMX", IsNullable = false)] 
        public PrescriptionUploadRowListParam DetailList { get; set; }
    }
}
