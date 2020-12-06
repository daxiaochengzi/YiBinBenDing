using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{
  public  class GetYdOutpatientPayCardParam: UiBaseDataParam
    {/// <summary>
    /// 划卡金额
    /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 社保卡类型
        /// </summary>
        public string InsuranceType { get; set; }

        /// <summary>
        /// 社保卡号
        /// </summary>
        public string MedicalInsuranceCardNo { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal AccountBalance { get; set; }

        /// <summary>
        /// 行政区划
        /// </summary>
        public string AreaCode { get; set; }
        public string SettlementJson { get; set; }

    }
}
