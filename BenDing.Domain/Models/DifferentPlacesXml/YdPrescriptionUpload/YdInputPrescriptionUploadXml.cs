using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDing.Domain.Models.DifferentPlacesXml.YdPrescriptionUpload
{
    /// <summary>
    /// 异地处方上传
    /// </summary>
    [XmlRootAttribute("ROW", IsNullable = false)]
    public  class YdInputPrescriptionUploadXml
    {   /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement("aac001", IsNullable = false)]
        public string PersonalCode { get; set; }
        /// <summary>
        /// 就诊记录号
        /// </summary>
        [XmlElement("aaz217", IsNullable = false)]
        public string VisitRecordNumber { get; set; }
        /// <summary>
        /// 参保地统筹区代码
        /// </summary>
        [XmlElement("baa008", IsNullable = false)]
        public string AreaCode { get; set; }
        
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlElement("bkc131", IsNullable = false)]
        public string Operators { get; set; }
        /// <summary>
        ///数量
        /// </summary>
        [XmlElement("nums", IsNullable = false)]
        public int nums { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [XmlElement("CFMX", IsNullable = false)]
        public YdPrescriptionUploadDetailParam DetailList { get; set; }
    }
}
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public class YdPrescriptionUploadDetailParam
{ /// <summary>
    ///  
    /// </summary>
    [XmlArrayAttribute("datarow")]
    [XmlArrayItem("ROW")]
    public List<YdPrescriptionUploadRowParam> RowDataList { get; set; }
}
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public class YdPrescriptionUploadRowParam
{
    /// <summary>
    /// 处方号 len(20)
    /// </summary>
    [XmlElementAttribute("aae072", IsNullable = false)]
    public string PrescriptionNum { get; set; }
    /// <summary>
    /// 医嘱记录序号
    /// </summary>
    [XmlElementAttribute("bkc127", IsNullable = false)]
    public string MedicalAdvice { get; set; }

    /// <summary>
    ///  处方序号（在医疗机构系统中产生的费用序号，一次就诊的序号不能重复）
    /// </summary>
    [XmlElementAttribute("bke019", IsNullable = false)]
    public string PrescriptionSort { get; set; }
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
    /// 医保项目分类
    /// </summary>
    [XmlElementAttribute("ake003", IsNullable = false)]
    public string ProjectCodeType { get; set; }
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
    /// 单位
    /// </summary>
    [XmlElementAttribute("aka067", IsNullable = false)]
    public string Unit { get; set; }


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
    /// 生产厂家
    /// </summary>
    [XmlElementAttribute("bkc046", IsNullable = false)]
    public string ManufacturerName { get; set; }
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
    /// 开处方日期 (yyyy-MM-dd HH:mm:ss)
    /// </summary>
    [XmlElementAttribute("bkc040", IsNullable = false)]
    public string DirectoryDate { get; set; }
  
   
    /// <summary>
    /// 限制审批标志
    /// </summary>
    [XmlElementAttribute("xzyyspbz", IsNullable = false)]
    public string LimitApprovalMark { get; set; }
   
    /// <summary>
    /// id
    /// </summary>
    [XmlIgnore]
    public Guid Id { get; set; }
    /// <summary>
    /// 明细id
    /// </summary>
    [XmlIgnore]
    public string DetailId { get; set; }
}