using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
    [XmlRoot("ROW", IsNullable = false)]
    public  class GetResidentOutpatientSettlementParam
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [XmlElementAttribute("PI_AKC190", IsNullable = false)]
        public string SerialNumber { get; set; }
        /// <summary>
        /// 报销方式
        /// </summary>
        [XmlElementAttribute("PI_AKA131", IsNullable = false)]
        public string ReimbursementType { get; set; }
        /// <summary>
        /// 身份标识 （身份证号或者个人编号）
        /// </summary>
        [XmlElementAttribute("PI_AAC002", IsNullable = false)]
        public string IdentityMark { get; set; }
        /// <summary>
        ///姓名
        /// </summary>
        [XmlElementAttribute("PI_AAC003", IsNullable = false)]
        public string PatientName { get; set; }
        /// <summary>
        ///密码
        /// </summary>
        [XmlElementAttribute("PI_PSW", IsNullable = false)]
        public string Pwd { get; set; }
        /// <summary>
        ///社保卡号
        /// </summary>
        [XmlElementAttribute("PI_CARDID", IsNullable = false)]
        public string InsuranceNo { get; set; }
        /// <summary>
        /// icd-10编码
        /// </summary>
        [XmlElementAttribute("PI_ICD10", IsNullable = false)]
        public string MainDiagnosisIcd10 { get; set; }

        /// <summary>
        /// 诊疾病名称
        /// </summary>
        [XmlElementAttribute("PI_JBMC", IsNullable = false)]
        public string MainDiagnosis { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [XmlElementAttribute("PI_NUM", IsNullable = false)]
        public int Num { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        [XmlElementAttribute("PI_AKB066", IsNullable = false)]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        [XmlElementAttribute("PI_XFSJ", IsNullable = false)]
        public string VisitDate { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [XmlArrayAttribute("ROWDATA")]
        [XmlArrayItem("ROW")]
        public List<GetResidentOutpatientSettlementRowParam> RowDataList { get; set; }
    }

    public class GetResidentOutpatientSettlementRowParam
    {/// <summary>
     /// 序号
     /// </summary>
        [XmlElementAttribute("BKE019", IsNullable = false)]
        public string ColNum { get; set; }

        /// <summary>
        /// 医保项目编号
        /// </summary>
        [XmlElementAttribute("AKE001", IsNullable = false)]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 院内项目名称
        /// </summary>
        [XmlElementAttribute("AKE002", IsNullable = false)]
        public string DirectoryName { get; set; }

        /// <summary>
        /// 单价   (12,4)
        /// </summary>
        [XmlElementAttribute("CKE521", IsNullable = false)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 数量   (12,4)
        /// </summary>
        [XmlElementAttribute("AKC226", IsNullable = false)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 总金额 ((12,4)每条费用明细的数据校验为传入的金额（四舍五入到两位小数）和传入的单价*传入的数量（四舍五入到两位小数）必须相等，检查不等的会提示报错
        /// </summary>
        [XmlElementAttribute("CKC526", IsNullable = false)]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [XmlElementAttribute("AKA074", IsNullable = false)]
        public string Specification { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        [XmlElementAttribute("CKA588", IsNullable = false)]
        public string Formulation { get; set; }
        /// <summary>
        /// 每次用量
        /// </summary>
        [XmlElementAttribute("BKC044", IsNullable = false)]

        public string Dosage { get; set; }
        /// <summary>
        /// 用法
        /// </summary>
        [XmlElementAttribute("BKC045", IsNullable = false)]

        public string Using { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        [XmlElementAttribute("BKC046", IsNullable = false)]

        public string ManufacturerName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [XmlElementAttribute("AAE013", IsNullable = false)]

        public string Remark { get; set; }

    }
}
