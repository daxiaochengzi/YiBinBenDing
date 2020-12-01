using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Infrastructures;

namespace BenDing.Domain.Models.Entitys
{
    /// <summary>
    /// 住院费用明细
    /// </summary>
    public class HospitalizationFee:IBaseEntity<HospitalizationFee>, IBaseDeleteAudited, IBaseCreationAudited, IBaseModificationAudited
    {
        /// <summary>
        /// 住院费用明细
        /// </summary>
        public HospitalizationFee()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 住院id
        /// </summary>
        public System.String HospitalizationId { get; set; }

        /// <summary>
        /// 费用明细ID
        /// </summary>
        public System.String DetailId { get; set; }

        /// <summary>
        /// 处方号
        /// </summary>
        public System.String DocumentNo { get; set; }

        /// <summary>
        /// 开单科室名称
        /// </summary>
        public System.String BillDepartment { get; set; }

        /// <summary>
        /// 项目名称[费用]
        /// </summary>
        public System.String DirectoryName { get; set; }

        /// <summary>
        /// 项目编码[费用]
        /// </summary>
        public System.String DirectoryCode { get; set; }

        /// <summary>
        /// 社保项目编码
        /// </summary>
        public System.String ProjectCode { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        public System.String Formulation { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public System.String Specification { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public System.Decimal? UnitPrice { get; set; }

        /// <summary>
        /// 用法
        /// </summary>
        public System.String Usage { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public System.Int32? Quantity { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public System.Decimal? Amount { get; set; }

        /// <summary>
        /// 费用单据类型
        /// </summary>
        public System.String DocumentType { get; set; }

        /// <summary>
        /// 开单科室编码
        /// </summary>
        public System.String BillDepartmentId { get; set; }

        /// <summary>
        /// 开单医生编码
        /// </summary>
        public System.String BillDoctorId { get; set; }

        /// <summary>
        /// 开单医生姓名
        /// </summary>
        public System.String BillDoctorName { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        public System.String Dosage { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public System.String Unit { get; set; }

        /// <summary>
        /// 开单时间
        /// </summary>
        public System.DateTime? BillTime { get; set; }

        /// <summary>
        /// 执行科室名称
        /// </summary>
        public System.String OperateDepartmentName { get; set; }

        /// <summary>
        /// 执行科室编码
        /// </summary>
        public System.String OperateDepartmentId { get; set; }

        /// <summary>
        /// 执行医生姓名
        /// </summary>
        public System.String OperateDoctorName { get; set; }

        /// <summary>
        /// 执行医生编码
        /// </summary>
        public System.String OperateDoctorId { get; set; }

        /// <summary>
        /// 门急费用标志
        /// </summary>
        public System.String DoorEmergencyFeeMark { get; set; }

        /// <summary>
        /// 医院审核标志
        /// </summary>
        public System.String HospitalAuditMark { get; set; }

        /// <summary>
        /// 院外检查标志
        /// </summary>
        public System.String OutHospitalInspectMark { get; set; }

        /// <summary>
        /// 机构编码[取接口30返回的ID]
        /// </summary>
        public System.String OrganizationCode { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public System.String OrganizationName { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public System.String BatchNumber { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public System.Int32? UploadMark { get; set; }

        /// <summary>
        /// 营业日期
        /// </summary>
        public System.DateTime? BusinessTimeDate { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public System.Int64? DataSort { get; set; }

        /// <summary>
        /// 调整差值
        /// </summary>
        public System.Decimal? AdjustmentDifferenceValue { get; set; }

        /// <summary>
        /// 交易id
        /// </summary>
        public System.String TransactionId { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public System.DateTime? UploadTime { get; set; }

        /// <summary>
        /// 上传人员名称
        /// </summary>
        public System.String UploadUserName { get; set; }

        /// <summary>
        /// 医保上传金额
        /// </summary>
        public System.Decimal? UploadAmount { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public System.DateTime? BusinessTime { get; set; }

        /// <summary>
        /// 审核标记
        /// </summary>
        public System.Int32? ApprovalMark { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public System.String ApprovalUserName { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public System.DateTime? ApprovalTime { get; set; }

        /// <summary>
        /// 审核用户id
        /// </summary>
        public System.String ApprovalUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.Byte[] Version { get; set; }

        /// <summary>
        /// 删除标记[0:默认,1:删除]
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public System.DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 操作员ID-[创建]
        /// </summary>
        public System.String CreateUserId { get; set; }

        /// <summary>
        /// 操作员ID-[删除]
        /// </summary>
        public System.String DeleteUserId { get; set; }

        /// <summary>
        /// 更新人员
        /// </summary>
        public System.String UpdateUserId { get; set; }

        /// <summary>
        /// 上传人员id
        /// </summary>
        public System.String UploadUserId { get; set; }

        /// <summary>
        /// 不传医保
        /// </summary>
        public System.Boolean? NotUploadMark { get; set; }

        /// <summary>
        /// 医嘱上传标识
        /// </summary>
        public System.Int32? DoctorAdviceUploadMark { get; set; }

        /// <summary>
        /// 医嘱上传人员id
        /// </summary>
        public System.String DoctorAdviceUploadUserId { get; set; }

        /// <summary>
        /// 医嘱上传人员名称
        /// </summary>
        public System.String DoctorAdviceUploadUserName { get; set; }

        /// <summary>
        /// 医嘱上传时间
        /// </summary>
        public System.DateTime? DoctorAdviceUploadTime { get; set; }
    }
}
