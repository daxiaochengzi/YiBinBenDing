using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.DifferentPlacesXml.YdPrescriptionUpload
{
    [XmlRoot("ROW", IsNullable = false)]
    public class YdOutputPrescriptionUploadXml
    { /// <summary>
      /// 处方明细上传时间
      /// </summary>

        [XmlElement("po_jbsj", IsNullable = false)]
        public string OperationTime { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("datarow")]
        [XmlArrayItem("ROW")]
        public List<YdOutputPrescriptionUploadRowXml> RowDataList { get; set; }

    }

    public class YdOutputPrescriptionUploadRowXml
    {
        /// <summary>
        /// 金额  (12,4)每条费用明细的数据校验为传入的金额（四舍五入到两位小数）和传入的单价*传入的数量（四舍五入到两位小数）必须相等，检查不等的会提示报错
        /// </summary>
        [XmlElementAttribute("akc264", IsNullable = false)]
        public decimal Amount { get; set; }
        /// <summary>
        ///  处方序号（在医疗机构系统中产生的费用序号，一次就诊的序号不能重复）
        /// </summary>
        [XmlElementAttribute("bke019", IsNullable = false)]
        public string PrescriptionSort { get; set; }
        /// <summary>
        /// 参保地限制使用标志
        /// </summary>
        [XmlElementAttribute("cbdxzyyspbz", IsNullable = false)]
        public string LimitedUseSign { get; set; }
      

    }
}
