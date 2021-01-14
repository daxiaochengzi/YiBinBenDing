using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class WorkerHospitalSettlementCardUiParam: UiBaseDataParam
    {/// <summary>
     /// 卡密码
     /// </summary>
        public string CardPwd { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public string AfferentSign { get; set; }
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string IdentityMark { get; set; }
        /// <summary>
        /// 下账金额
        /// </summary>
        public  decimal DownAmount { get; set; }
        /// <summary>
        /// 社保类型
        /// </summary>
        public string InsuranceType { get; set; }
        /// <summary>
        /// 结算xml
        /// </summary>
        public string SettlementJson { get; set; }
    }
}
