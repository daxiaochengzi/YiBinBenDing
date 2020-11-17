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
     /// 生育保险支付
     /// </summary>
        [JsonProperty(PropertyName = "po_sybxzf")]
        public decimal BirthPayAmount { get; set; }
        /// <summary>
        /// 不享受待遇原因
        /// </summary>
        [JsonProperty(PropertyName = "po_bxsdyyy")]
        public string NoTreatment { get; set; }
        /// <summary>
        /// 公务员支付
        /// </summary>
        [JsonProperty(PropertyName = "po_gwyzf")]
        public decimal CivilServantsPayAmount { get; set; }
        /// <summary>
        /// 新农合支付
        /// </summary>
        [JsonProperty(PropertyName = "po_xnhzf")]
        public decimal NcmsAmount { get; set; }

        /// <summary>
        ///  其它支付金额
        /// </summary>
        [JsonProperty(PropertyName = "po_qtxzzf")]
        public decimal OtherPaymentAmount { get; set; }
       

        /// <summary>
        /// 结算单据号
        /// </summary>
        [JsonProperty(PropertyName = "po_djh")]
        public string DocumentNo { get; set; }
        /// <summary>
        /// 居民统筹支付
        /// </summary>
        [JsonProperty(PropertyName = "po_jmtczf")]
        public decimal OverallPlanningResidentsPayAmount { get; set; }
        /// <summary>
        /// 险种
        /// </summary>
        [JsonProperty(PropertyName = "po_xzlx")]
        public string InsuranceType { get; set; }
        /// <summary>
        /// 享受待遇标识
        /// </summary>
        [JsonProperty(PropertyName = "po_xsdybs")]
        public string BenefitsSign { get; set; }

        /// <summary>
        /// 超限价自付
        /// </summary>
        [JsonProperty(PropertyName = "po_cxjzf")]
        public decimal LimitPayAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "po_cxjzf")]
        public decimal AccountBalanceAmount { get; set; }
        /// <summary>
        /// 费用总额
        /// </summary>
        [JsonProperty(PropertyName = "po_fyze")]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 账户最高可支付金额
        /// </summary>
        [JsonProperty(PropertyName = "po_zhzgkzf")]
        public decimal AvailableAmount { get; set; }
        /// <summary>
        /// 基本统筹支付
        /// </summary>
        [JsonProperty(PropertyName = "po_tczf")]
        public decimal BasicOverallPay { get; set; }
        /// <summary>
        /// 起付金额
        /// </summary>
        [JsonProperty(PropertyName = "po_qfje")]
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        [JsonProperty(PropertyName = "po_xjzf")]
        public decimal CashPayAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
        [JsonProperty(PropertyName = "po_zhzf")]
        public decimal AccountPayAmount { get; set; }
        /// <summary>
        /// 先自付金额
        /// </summary>
        [JsonProperty(PropertyName = "po_xzfje")]
        public decimal BeforeSelfPayAmount { get; set; }
        /// <summary>
        ///纯自费金额
        /// </summary>
        [JsonProperty(PropertyName = "po_czfje")]
        public decimal AfterSelfPayAmount { get; set; }
        /// <summary>
        ///报销说明
        /// </summary>
        [JsonProperty(PropertyName = "po_bxqksm")]
        public string ReimbursementRemark { get; set; }

        /// <summary>
        ///报销范围金额
        /// </summary>
        [JsonProperty(PropertyName = "po_jrbxje")]
        public decimal ReimbursementRangeAmount { get; set; }
        /// <summary>
        ///社保支付合计
        /// </summary>
        [JsonProperty(PropertyName = "po_sbzfhj")]
        public decimal MedicalInsuranceTotalPayAmount { get; set; }
        /// <summary>
        /// 补充医疗保险支付
        /// </summary>
        [JsonProperty(PropertyName = "po_bcylzf")]
        public decimal SupplementPayAmount { get; set; }
        /// <summary>
        /// 居民大病保险支付
        /// </summary>
        [JsonProperty(PropertyName = "po_jmdbzf")]
        public decimal SeriousIllnessPayAmount { get; set; }
        /// <summary>
        /// 接口返回值
        /// </summary>
        [JsonProperty(PropertyName = "po_fhz")]
        
        public  string InterfaceStatus { get; set; }

        /// <summary>
        /// 接口返回信息
        /// </summary>
        [JsonProperty(PropertyName = "po_msg")]

        public string InterfaceMsg { get; set; }
    }
}
