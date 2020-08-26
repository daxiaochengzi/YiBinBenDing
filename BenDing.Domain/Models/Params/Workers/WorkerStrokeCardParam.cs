using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.Workers
{/// <summary>
/// 
/// </summary>
  public  class WorkerStrokeCardParam: WorkerBaseParam
    {
        /// <summary>
        /// 合计金额(2位小数)
        /// </summary>
        public  decimal  AllAmount { get; set; }
        /// <summary>
        /// 卡类别(1门诊,2住院)
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// Id        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string DocumentNo { get; set; }
        /// <summary>
        /// 自费金额
        /// </summary>
        public decimal SelfPayFeeAmount { get; set; }
        /// <summary>
        /// 账户支付金额
        /// </summary>
        public decimal AccountPayAmount { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }

    }
}
