using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces
{
    /// <summary>
    /// 异地预结算
    /// </summary>
   public class YdHospitalizationPreSettlementJsonDto
    {  /// <summary>
        /// 费用总额
        /// </summary>
        [JsonProperty(PropertyName = "费用总额")]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        [JsonProperty(PropertyName = "现金支付")]
        public decimal CashPayAmount { get; set; }
        /// <summary>
        ///社保支付合计
        /// </summary>
        [JsonProperty(PropertyName = "社保支付合计")]
        public decimal MedicalInsuranceTotalPayAmount { get; set; }
        /// <summary>
        /// 账户可支付金额
        /// </summary>
        [JsonProperty(PropertyName = "账户可支付金额")]
        public decimal AvailableAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "账户余额")]
        public decimal AccountBalanceAmount { get; set; }
        /// <summary>
        /// 起付金额
        /// </summary>
        [JsonProperty(PropertyName = "起付金额")]
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// 生育保险支付
        /// </summary>
        [JsonProperty(PropertyName = "生育保险支付")]
        public decimal BirthPayAmount { get; set; }
        /// <summary>
        /// 公务员支付
        /// </summary>
        [JsonProperty(PropertyName = "公务员支付")]
     
        public decimal CivilServantsPayAmount { get; set; }
        /// <summary>
        ///  其它支付金额
        /// </summary>
        [JsonProperty(PropertyName = "其它支付金额")]
        public decimal OtherPaymentAmount { get; set; }
        /// <summary>
        /// 居民统筹支付
        /// </summary>
        [JsonProperty(PropertyName = "居民统筹支付")]
        public decimal OverallPlanningResidentsPayAmount { get; set; }
        /// <summary>
        /// 基本统筹支付
        /// </summary>
        [JsonProperty(PropertyName = "基本统筹支付")]
        public decimal BasicOverallPay { get; set; }
       

        /// <summary>
        /// 补充医疗保险支付
        /// </summary>
        [JsonProperty(PropertyName = "补充医疗保险支付")]
        public decimal SupplementPayAmount { get; set; }
        /// <summary>
        /// 居民大病保险支付
        /// </summary>
        [JsonProperty(PropertyName = "居民大病保险支付")]
        public decimal SeriousIllnessPayAmount { get; set; }
      
    }
}
