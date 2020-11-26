using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.DifferentPlacesXml.HospitalizationPreSettlement
{
    [XmlRoot("ROW", IsNullable = false)]
    public  class YdOutputHospitalizationPreSettlementXml
    { /// <summary>
      /// 生育保险支付
      /// </summary>
       
        [XmlElement("po_sybxzf", IsNullable = false)]
        public decimal BirthPayAmount { get; set; }
        /// <summary>
        /// 不享受待遇原因
        /// </summary>
       
        [XmlElement("po_bxsdyyy", IsNullable = false)]
        public string NoTreatment { get; set; }
        /// <summary>
        /// 公务员支付
        /// </summary>
      
        [XmlElement("po_gwyzf", IsNullable = false)]
        public decimal CivilServantsPayAmount { get; set; }
        /// <summary>
        /// 新农合支付
        /// </summary>
       
        [XmlElement("po_xnhzf", IsNullable = false)]
        public decimal NcmsAmount { get; set; }

        /// <summary>
        ///  其它支付金额
        /// </summary>
      
        [XmlElement("po_qtxzzf", IsNullable = false)]
        public decimal OtherPaymentAmount { get; set; }


        /// <summary>
        /// 结算单据号
        /// </summary>
       
        [XmlElement("po_djh", IsNullable = false)]
        public string DocumentNo { get; set; }
        /// <summary>
        /// 居民统筹支付
        /// </summary>
       
        [XmlElement("po_jmtczf", IsNullable = false)]
        public decimal OverallPlanningResidentsPayAmount { get; set; }
        /// <summary>
        /// 险种
        /// </summary>
        [JsonProperty(PropertyName = "po_xzlx")]
        [XmlElement("po_xzlx", IsNullable = false)]
        public string InsuranceType { get; set; }
        /// <summary>
        /// 享受待遇标识
        /// </summary>
       
        [XmlElement("po_xsdybs", IsNullable = false)]
        public string BenefitsSign { get; set; }

        /// <summary>
        /// 超限价自付
        /// </summary>
       
        [XmlElement("po_cxjzf", IsNullable = false)]
        public decimal LimitPayAmount { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
       
        [XmlElement("po_zhzf", IsNullable = false)]
        public decimal AccountBalanceAmount { get; set; }
        /// <summary>
        /// 费用总额
        /// </summary>
       
        [XmlElement("po_fyze", IsNullable = false)]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 账户最高可支付金额
        /// </summary>
      
        [XmlElement("po_zhzgkzf", IsNullable = false)]
        public decimal AvailableAmount { get; set; }
        /// <summary>
        /// 基本统筹支付
        /// </summary>
       
        [XmlElement("po_tczf", IsNullable = false)]
        public decimal BasicOverallPay { get; set; }
        /// <summary>
        /// 起付金额
        /// </summary>
     
        [XmlElement("po_qfje", IsNullable = false)]
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
     
        [XmlElement("po_xjzf", IsNullable = false)]
        public decimal CashPayAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
       
        [XmlElement("po_zhzf", IsNullable = false)]
        public decimal AccountPayAmount { get; set; }
        /// <summary>
        /// 先自付金额
        /// </summary>
      
        [XmlElement("po_xzfje", IsNullable = false)]
        public decimal BeforeSelfPayAmount { get; set; }
        /// <summary>
        ///纯自费金额
        /// </summary>
   
        [XmlElement("po_czfje", IsNullable = false)]
        public decimal AfterSelfPayAmount { get; set; }
        /// <summary>
        ///报销说明
        /// </summary>
      
        [XmlElement("po_bxqksm", IsNullable = false)]
        public string ReimbursementRemark { get; set; }

        /// <summary>
        ///报销范围金额
        /// </summary>
      
        [XmlElement("po_jrbxje", IsNullable = false)]
        public decimal ReimbursementRangeAmount { get; set; }
        /// <summary>
        ///社保支付合计
        /// </summary>
      
        [XmlElement("po_sbzfhj", IsNullable = false)]
        public decimal MedicalInsuranceTotalPayAmount { get; set; }
        /// <summary>
        /// 补充医疗保险支付
        /// </summary>
     
        [XmlElement("po_bcylzf", IsNullable = false)]
        public decimal SupplementPayAmount { get; set; }
        /// <summary>
        /// 居民大病保险支付
        /// </summary>
       
        [XmlElement("po_jmdbzf", IsNullable = false)]
        public decimal SeriousIllnessPayAmount { get; set; }
        /// <summary>
        /// 接口返回值
        /// </summary>
   
        [XmlElement("po_fhz", IsNullable = false)]

        public string InterfaceStatus { get; set; }

        /// <summary>
        /// 接口返回信息
        /// </summary>
     
        [XmlElement("po_msg", IsNullable = false)]

        public string InterfaceMsg { get; set; }
    }
}
