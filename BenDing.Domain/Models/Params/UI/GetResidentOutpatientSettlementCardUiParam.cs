using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
  public  class GetResidentOutpatientSettlementCardUiParam: UiBaseDataParam
    {  /// <summary>
    /// 密码
    /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 结算json
        /// </summary>
        public string SettlementJson { get; set; }

    }
}
