using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{/// <summary>
/// 取消划卡参数
/// </summary>
    [XmlRoot("ROW", IsNullable = false)]
    public class WorkerCancelSettlementCardParam
    {
        /// <summary>
        /// 划卡流水号
        /// </summary>
        [XmlElementAttribute("PI_HKLSH", IsNullable = false)]
       
        public string SettlementNo { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [XmlElementAttribute("PI_JBR", IsNullable = false)]
        public string OperatorName { get; set; }

        /// <summary>
        /// 取消结算备注
        /// </summary>
        ///
        [XmlElementAttribute("PI_AAE013", IsNullable = false)]
        public string CancelRemarks { get; set; }
    }
}
