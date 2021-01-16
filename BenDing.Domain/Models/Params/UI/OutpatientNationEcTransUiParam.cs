using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
  public  class OutpatientNationEcTransUiParam:UiBaseDataParam
    {
        ///// <summary>
        ///// 下账金额
        ///// </summary>
        //public string DownAccountAmount { get; set; }
        ///// <summary>
        /////   备注说明
        ///// </summary>
        //public string Remark { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public  string AfferentSign { get; set; }
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string IdentityMark { get; set; }
        /// <summary>
        /// 社保类型
        /// </summary>
        public string InsuranceType { get; set; }
        
        /// <summary>
        /// 结算xml
        /// </summary>
        public string SettlementJson { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public string AccountBalance { get; set; }
        /// <summary>
        /// 参保地
        /// </summary>
        public string CommunityName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddress { get; set; }

    }
}
