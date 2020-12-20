using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
  public  class ResidentOutpatientSettlementCardParam:UiBaseDataParam
    {
       /// <summary>
       /// 支付密码
       /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string InsuranceNo { get; set; }
    }
}
