using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Infrastructures;

namespace BenDing.Domain.Models.Entitys
{
    /// <summary>
    /// 住院病人
    /// </summary>
    public class Inpatient: IBaseEntity<Inpatient>, IBaseDeleteAudited, IBaseCreationAudited, IBaseModificationAudited
    {
        /// <summary>
        /// 住院病人
        /// </summary>
        public Inpatient()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 住院Id
        /// </summary>
        public System.String HospitalizationId { get; set; }

        /// <summary>
        /// 住院号
        /// </summary>
        public System.String HospitalizationNo { get; set; }

        /// <summary>
        /// 入院日期
        /// </summary>
        public System.DateTime? AdmissionDate { get; set; }

        /// <summary>
        /// 出院日期
        /// </summary>
        public System.DateTime? LeaveHospitalDate { get; set; }

        /// <summary>
        /// 业务ID/住院ID
        /// </summary>
        public System.String BusinessId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public System.String PatientName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public System.String IdCardNo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public System.String PatientSex { get; set; }

        /// <summary>
        /// 诊断Json
        /// </summary>
        public System.String DiagnosisJson { get; set; }

        /// <summary>
        /// 主要诊断
        /// </summary>
        public System.String AdmissionMainDiagnosis { get; set; }

        /// <summary>
        /// 入院诊断
        /// </summary>
        public System.String AdmissionMainDiagnosisIcd10 { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
        public System.String DocumentNo { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public System.String ContactName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public System.String ContactPhone { get; set; }

        /// <summary>
        /// 家庭地址
        /// </summary>
        public System.String FamilyAddress { get; set; }

        /// <summary>
        /// 入院科室
        /// </summary>
        public System.String InDepartmentName { get; set; }

        /// <summary>
        /// 入院科室编码
        /// </summary>
        public System.String InDepartmentId { get; set; }

        /// <summary>
        /// 入院诊断医生
        /// </summary>
        public System.String AdmissionDiagnosticDoctor { get; set; }

        /// <summary>
        /// 入院床位
        /// </summary>
        public System.String AdmissionBed { get; set; }

        /// <summary>
        /// 入院经办人
        /// </summary>
        public System.String AdmissionOperator { get; set; }

        /// <summary>
        /// 入院经办时间
        /// </summary>
        public System.DateTime? AdmissionOperateTime { get; set; }

        /// <summary>
        /// 住院总费用
        /// </summary>
        public System.Decimal? HospitalizationTotalCost { get; set; }

        /// <summary>
        /// 总费用
        /// </summary>
        public System.Decimal? TotalFee { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String Remark { get; set; }

        /// <summary>
        /// 入院诊断医生编码
        /// </summary>
        public System.String AdmissionDiagnosticDoctorId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String OrganizationCode { get; set; }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public System.String OrganizationName { get; set; }

        /// <summary>
        /// 出院诊断json
        /// </summary>
        public System.String LeaveHospitalDiagnosisJson { get; set; }

        /// <summary>
        /// 出院科室编码
        /// </summary>
        public System.String LeaveHospitalDepartmentId { get; set; }

        /// <summary>
        /// 出院科室名称
        /// </summary>
        public System.String LeaveHospitalDepartmentName { get; set; }

        /// <summary>
        /// 出院床位
        /// </summary>
        public System.String LeaveHospitalBedNumber { get; set; }

        /// <summary>
        /// 出院诊断医生
        /// </summary>
        public System.String LeaveHospitalDiagnosticDoctor { get; set; }

        /// <summary>
        /// 出院经办人
        /// </summary>
        public System.String LeaveHospitalOperator { get; set; }

        /// <summary>
        /// 是否取消基层入院登记
        /// </summary>
        public System.Int32? IsCanCelHospitalized { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新标记
        /// </summary>
        public System.Byte[] Version { get; set; }

        /// <summary>
        /// 删除标记[0:默认,1:删除]
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

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
    }
}
