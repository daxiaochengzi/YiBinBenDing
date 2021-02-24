using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{
  public  class GetYdOutpatientPayCardParam : UiBaseDataParam
    {
        /// <summary>
        /// 卡号
        /// </summary>
        [Display(Name = "卡号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 行政区域
        /// </summary>
        [Display(Name = "行政区域")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string AreaCode { get; set; }
       /// <summary>
        /// 下账金额
       /// </summary>
        public  decimal DownAmount { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public string AfferentSign { get; set; }
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string IdentityMark { get; set; }
        /// <summary>
        /// 结算xml
        /// </summary>
        public string SettlementJson { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal AccountBalance { get; set; }
    }
}
