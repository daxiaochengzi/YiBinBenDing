using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.DifferentPlacesXml.LeaveHospital
{
    [XmlRoot("ROW", IsNullable = false)]
   public class YdOutputLeaveHospitalHandleXml
    {
        /// <summary>
        /// 经办时间
        /// </summary>
      
        [XmlElement("po_jbsj", IsNullable = false)]
        public string OperationTime { get; set; }
        /// <summary>
        /// 出院交易流水号
        /// </summary>

        [XmlElement("po_jylsh", IsNullable = false)]
        public string LeaveHospitalSerialNumber { get; set; }
    }
}
