using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.Params.DifferentPlaces
{/// <summary>
 /// 异地门诊预结算   
 /// </summary>
    [XmlRoot("ROW", IsNullable = false)]
    public class YdOutpatientPreSettlementParam
    { /// <summary>
        /// 参保地统筹区代码
        /// </summary>
        [XmlElement("baa008", IsNullable = false)]
        public string AreaCode { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string OutpatientNumber { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        [XmlElement("aac003", IsNullable = false)]
        public string PatientName { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>

        [XmlElement("aac001", IsNullable = false)]
        public string PersonalCode { get; set; }
        /// <summary>
        /// 社会保障卡卡号
        /// </summary>
        [XmlElement("aaz500", IsNullable = false)]
        public string CardNumber { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [XmlElement("aac002", IsNullable = false)]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 医疗类别代码
        /// </summary>
        [XmlElement("aka130", IsNullable = false)]
        public string MedicalTypeCode { get; set; }
        /// <summary>
        /// 清算分中心
        /// </summary>
        [XmlElement("bka013", IsNullable = false)]
        public string ClearingSubCenter { get; set; }
        /// <summary>
        /// 清算类别
        /// </summary>
        [XmlElement("bka015", IsNullable = false)]
        public string ClearingType { get; set; }
        /// <summary>
        /// 诊断编码1
        /// </summary>
        [XmlElement("akc193", IsNullable = false)]
        public string DiagnosisCodeOne { get; set; }
        /// <summary>
        /// 诊断编码2
        /// </summary>
        [XmlElement("bkc021", IsNullable = false)]
        public string DiagnosisCodeTwo { get; set; }
        /// <summary>
        /// 诊断编码3
        /// </summary>
        [XmlElement("bkc022", IsNullable = false)]
        public string DiagnosisCodeThree { get; set; }
        /// <summary>
        /// 门诊诊断中文名称(医院来组织)
        /// </summary>
        [XmlElement("bkc020", IsNullable = false)]
        public string MainDiagnosisName { get; set; }
        /// <summary>
        /// 特慢病病种编码（全省统一编码）
        /// </summary>
        [XmlArrayAttribute("disease")]
        [XmlArrayItem("ROW")]
        public List<YdOutpatientPreSettlementDiseaseRowParam> DiseaseRowList { get; set; }
        /// <summary>
        /// 诊断编码
        /// </summary>
        [XmlArrayAttribute("bkc033")]
        [XmlArrayItem("ROW")]
        public List<YdOutpatientPreSettlementDiagnosisRowParam> DiagnosisRowList { get; set; }
        /// <summary>
        /// 本次个人账户拟下账金额
        /// </summary>
        [XmlElement("bkc142", IsNullable = false)]
        public Decimal DownAccountAmount { get; set; }
        /// <summary>
        ///数量
        /// </summary>
        [XmlElement("nums", IsNullable = false)]
        public string nums { get; set; }
        /// <summary>
        /// 开处方日期 (yyyy-mm-dd)
        /// </summary>
        [XmlElementAttribute("aae030", IsNullable = false)]
        public string DirectoryDate { get; set; }
        /// <summary>
        /// 数据明细列表
        /// </summary>
        [XmlElementAttribute("mzfymx", IsNullable = false)]
        public YdOutpatientPreSettlementDetailRowListParam DetailRowList { get; set; }


    }
    /// <summary>
    /// 特慢病病种编码（全省统一编码）
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdOutpatientPreSettlementDiseaseRowParam
    {/// <summary>
     /// 特慢病病种编码（全省统一编码）
     /// </summary>
        [XmlElement("bkc014", IsNullable = false)]
        public string SlowSpecialDiseaseCode { get; set; }
        
    }
    /// <summary>
    /// 特慢病病种编码（全省统一编码）
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdOutpatientPreSettlementDiagnosisRowParam
    {/// <summary>
     /// 入院次要诊断编码
     /// </summary>
        [XmlElement("bkc022", IsNullable = false)]
        public string DiagnosisCode { get; set; }
        /// <summary>
        /// 入院次要诊断名称
        /// </summary>
        [XmlElement("akc076", IsNullable = false)]
        public string DiagnosisName { get; set; }
    }
    /// <summary>
    /// 费用明细列表
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdOutpatientPreSettlementDetailRowListParam
    { /// <summary>
        /// 诊断编码
        /// </summary>
        [XmlArrayAttribute("datarow")]
        [XmlArrayItem("ROW")]
        public List<YdOutpatientPreSettlementDetailRowParam> DiagnosisRowList { get; set; }
    }
    /// <summary>
    /// 费用明细行
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class YdOutpatientPreSettlementDetailRowParam
    {/// <summary>
        ///  处方序号（在医疗机构系统中产生的费用序号，一次就诊的序号不能重复）
        /// </summary>
        [XmlElementAttribute("bke019", IsNullable = false)]
        public int PrescriptionSort { get; set; }
        /// <summary>
        /// 项目编号 全省统一收费目录编码
        /// </summary>
        [XmlElementAttribute("aaz231", IsNullable = false)]
        public string ProjectCode { get; set; }
        /// <summary>
        /// 院内目录固定编码 len(20)
        /// </summary>
        [XmlElementAttribute("bke026", IsNullable = false)]
        public string FixedEncoding { get; set; }
        /// <summary>
        /// 医院内项目名称(诊疗项目)
        /// </summary>
        [XmlElementAttribute("bke027", IsNullable = false)]
        public string ProjectName { get; set; }
        /// <summary>
        /// 医院内剂型
        /// </summary>
        [XmlElementAttribute("aka070_yn", IsNullable = false)]
        public string Formulation { get; set; }
        /// <summary>
        /// 医院内规格
        /// </summary>
        [XmlElementAttribute("aka074_yn", IsNullable = false)]
        public string Specification { get; set; }
        /// <summary>
        /// 最小收费单位
        /// </summary>
        [XmlElementAttribute("aka067", IsNullable = false)]
        public string MinUnit { get; set; }

        /// <summary>
        /// 本单收费单位
        /// </summary>
        [XmlElementAttribute("aka067_yn", IsNullable = false)]
        public string Unit { get; set; }
        /// <summary>
        /// 数量   (12,4)
        /// </summary>
        [XmlElementAttribute("akc226", IsNullable = false)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 单价   (12,4)
        /// </summary>
        [XmlElementAttribute("akc225", IsNullable = false)]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金额  (12,4)每条费用明细的数据校验为传入的金额（四舍五入到两位小数）和传入的单价*传入的数量（四舍五入到两位小数）必须相等，检查不等的会提示报错
        /// </summary>
        [XmlElementAttribute("akc264", IsNullable = false)]
        public decimal Amount { get; set; }
        /// <summary>
        /// 开单医生编码
        /// </summary>
        [XmlElementAttribute("bkc048", IsNullable = false)]
        public string DoctorJobNumber { get; set; }
        /// <summary>
        /// 开单医生姓名
        /// </summary>
        [XmlElementAttribute("bkc049", IsNullable = false)]
        public string DoctorName { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [XmlElementAttribute("aae386", IsNullable = false)]
        public string InDepartmentName { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        [XmlElementAttribute("aaz307", IsNullable = false)]
        public string InDepartmentCode { get; set; }
        /// <summary>
        /// 用量
        /// </summary>
        [XmlElementAttribute("bkc044", IsNullable = false)]
        public decimal Dosage { get; set; }
        /// <summary>
        /// 用法
        /// </summary>
        [XmlElementAttribute("bkc045", IsNullable = false)]
        public string Usage { get; set; }
        /// <summary>
        ///  与单次用量同单位规格(数值型)
        /// </summary>
        [XmlElementAttribute("aka074", IsNullable = false)]
        public int SameSpecification { get; set; }
        /// <summary>
        /// 医保项目分类
        /// </summary>
        [XmlElementAttribute("ake003", IsNullable = false)]
        public string ProjectCodeType { get; set; }
    }
}
