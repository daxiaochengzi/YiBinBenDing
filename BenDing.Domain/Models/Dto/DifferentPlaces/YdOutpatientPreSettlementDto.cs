using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Dto.DifferentPlaces
{
    [XmlRoot("ROW", IsNullable = false)]
    public class YdOutpatientPreSettlementDto
    {
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
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("po_jylsh", IsNullable = false)]
        public string TransactionSerialNumber { get; set; }
    
        /// <summary>
        /// 就诊登记号
        /// </summary>
        [XmlElement("aaz217", IsNullable = false)]
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// 人员医疗结算事件id(就诊结算id)
        /// </summary>
        [XmlElement("aaz216", IsNullable = false)]
        public string SettlementId { get; set; }
        /// <summary>
        /// 清算类别
        /// </summary>
        [XmlElement("bka015", IsNullable = false)]
        public string ClearSettlementType { get; set; }
        /// <summary>
        /// 参保地统筹区编号
        /// </summary>
        [XmlElement("baa008", IsNullable = false)]
        
        public  string JoinAreaCode { get; set; }
        /// <summary>
        /// 参保地分中心编码
        /// </summary>
        [XmlElement("baa009", IsNullable = false)]

        public string SubCenterAreaCode { get; set; }
        /// <summary>
        /// 就医地统筹区编号
        /// </summary>
        [XmlElement("baa010", IsNullable = false)]
        public string MedicineAreaCode { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement("aac001", IsNullable = false)]
        public string PersonalCode { get; set; }
        /// <summary>
        /// 参保身份
        /// </summary>
        [XmlElement("aac066", IsNullable = false)]
        public string InsuredStatus { get; set; }
        /// <summary>
        /// 特殊人员类别
        /// </summary>
        [XmlElement("bkc113", IsNullable = false)]
        public string SpecialPersonnelCategory { get; set; }
        /// <summary>
        /// 费用结算时间
        /// </summary>
        [XmlElement("bkc060", IsNullable = false)]
        public string SettlementTime { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        [XmlElement("akc264", IsNullable = false)]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 全自费部分
        /// </summary>
        [XmlElement("akc253", IsNullable = false)]
        public decimal AllSelfAmount { get; set; }
        /// <summary>
        /// 先自付部分
        /// </summary>
        [XmlElement("akc228", IsNullable = false)]
        public decimal BeforeSelfAmount { get; set; }

        /// <summary>
        /// 超限价自付
        /// </summary>
       
        [XmlElement("akc268", IsNullable = false)]
        public decimal LimitPayAmount { get; set; }
        /// <summary>
        /// 进入报销范围部分
        /// </summary>
        [XmlElement("bkc042", IsNullable = false)]
        
        public decimal ReimbursementRangeAmount { get; set; }
        /// <summary>
        /// 本次起付线
        /// </summary>
        [XmlElement("bke002", IsNullable = false)]

        public decimal DeductibleAmount { get; set; }
        /// <summary>
        /// 本年累积起付线
        /// </summary>
        [XmlElement("bke003", IsNullable = false)]

        public decimal YearTotalDeductibleAmount { get; set; }
        /// <summary>
        /// 个人账户支付
        /// </summary>
        [XmlElement("akb066", IsNullable = false)]
        public decimal AccountPayAmount { get; set; }
        /// <summary>
        /// 医保统筹支付合计（不包含个人账户支付）
        /// </summary>
        [XmlElement("akb068", IsNullable = false)]
        public decimal MedicalInsuranceOverallPay { get; set; }

        /// <summary>
        /// 现金支付
        /// </summary>
        [XmlElement("akb067", IsNullable = false)]
        public decimal CashPayAmount { get; set; }
        /// <summary>
        /// 账户最高可支付金额
        /// </summary>
        [XmlElement("bkc143", IsNullable = false)]
        public decimal AvailableAmount { get; set; }
        /// <summary>
        /// 城镇职工基本保险
        /// </summary>
        [XmlElement("ake039", IsNullable = false)]
        public decimal WorkersMedicalInsurance { get; set; }
        /// <summary>
        /// 公务员医疗保险
        /// </summary>
        [XmlElement("ake035", IsNullable = false)]
        public decimal CivilServantsPayAmount { get; set; }
        /// <summary>
        ///城镇职工补充保险
        /// </summary>
        [XmlElement("ake029", IsNullable = false)]
        public decimal WorkersSupplementPayAmount { get; set; }
       ///<summary>
        /// 生育保险支付
        /// </summary>
        
        [XmlElement("ame001", IsNullable = false)]
        public decimal BirthPayAmount { get; set; }
        ///<summary>
        /// 居民门诊统筹
        /// </summary>

        [XmlElement("ake039_jm", IsNullable = false)]
      
        public decimal OverallPlanningOutpatientPayAmount { get; set; }
        /// <summary>
        /// 居民大病保险支付
        /// </summary>
       
        [XmlElement("bkc010", IsNullable = false)]
        public decimal SeriousIllnessPayAmount { get; set; }
        /// <summary>
        /// 新农合
        /// </summary>

        [XmlElement("ake039_xnh", IsNullable = false)]
        public decimal NcmsPayAmount { get; set; }

        /// <summary>
        ///  其它支付金额
        /// </summary>

        [XmlElement("ke039_qt", IsNullable = false)]
        public decimal OtherPaymentAmount { get; set; }
        /// <summary>
        ///报销说明
        /// </summary>
      
        [XmlElement("bke031", IsNullable = false)]
        public string ReimbursementRemark { get; set; }
        /// <summary>
        /// 医保结算时间
        /// </summary>
        [XmlElement("aae036", IsNullable = false)]
        public string MedicalInsuranceSettlementTime { get; set; }

        /// <summary>
        ///  结算反馈信息
        /// </summary>
        [XmlArrayAttribute("datarow")]
        [XmlArrayItem("ROW")]
        public List<YdOutpatientPreSettlementRowDto> RowDataList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdOutpatientPreSettlementRowDto
    {   /// <summary>
        ///  处方序号（在医疗机构系统中产生的费用序号，一次就诊的序号不能重复）
        /// </summary>
        [XmlElementAttribute("bke019", IsNullable = false)]
        public int PrescriptionSort { get; set; }
        /// <summary>
        /// 金额  (12,4)每条费用明细的数据校验为传入的金额（四舍五入到两位小数）和传入的单价*传入的数量（四舍五入到两位小数）必须相等，检查不等的会提示报错
        /// </summary>
        [XmlElementAttribute("akc264", IsNullable = false)]
        public decimal Amount { get; set; }
        /// <summary>
        /// 定价上限金额
        /// </summary>
        [XmlElementAttribute("aka068", IsNullable = false)]
        public decimal PricingCapAmount { get; set; }
        /// <summary>
        /// 自付比例
        /// </summary>
        [XmlElementAttribute("aka057", IsNullable = false)]
        public decimal SelfProportion { get; set; }
        /// <summary>
        /// 全自费
        /// </summary>
        [XmlElementAttribute("akc253", IsNullable = false)]
        public decimal TotalSelfAmount { get; set; }

        /// <summary>
        /// 先自费
        /// </summary>
        [XmlElementAttribute("akc253", IsNullable = false)]
        public decimal BeforeSelfAmount { get; set; }
        /// <summary>
        /// 超限自费
        /// </summary>
        [XmlElementAttribute("akc268", IsNullable = false)]
        public decimal LimitSelfAmount { get; set; }

        /// <summary>
        ///报销范围金额
        /// </summary>
       
        [XmlElementAttribute("kc042", IsNullable = false)]
        public decimal ReimbursementRangeAmount { get; set; }
        /// <summary>
        ///项目等级
        /// </summary>

        [XmlElementAttribute("aka065", IsNullable = false)]
        public decimal ProjectLevel { get; set; }
        
    }
}
