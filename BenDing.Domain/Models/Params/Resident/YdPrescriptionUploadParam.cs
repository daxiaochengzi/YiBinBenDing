using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.Resident
{
   //public class YdPrescriptionUploadParam
   // {
   // }
    [XmlRoot("ROW", IsNullable = false)]
    public class YdPrescriptionUploadParam
    {
        /// <summary>
        /// 医保住院号
        /// </summary>
        [XmlElementAttribute("PI_ZYH", IsNullable = false)]
        public string MedicalInsuranceHospitalizationNo { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElementAttribute("PI_JBR", IsNullable = false)]
        public string Operators { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("CFMX")]
        [XmlArrayItem("ROW")]
        public List<PrescriptionUploadRowParam> RowDataList { get; set; }
    }
  
}
