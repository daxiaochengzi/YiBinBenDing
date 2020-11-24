using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenDing.Domain.Infrastructures;

namespace BenDing.Domain.Models.Entitys
{
    /// <summary>
    /// 住院医保信息
    /// </summary>
    public class MedicalInsurance : IBaseEntity<MedicalInsurance>, IBaseDeleteAudited, IBaseCreationAudited, IBaseModificationAudited
    {
        
            /// <summary>
            /// 住院医保信息
            /// </summary>
            public MedicalInsurance()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            public System.Guid Id { get; set; }

            /// <summary>
            /// 业务ID
            /// </summary>
            public System.String BusinessId { get; set; }

            /// <summary>
            /// 医保卡号
            /// </summary>
            public System.String InsuranceNo { get; set; }

            /// <summary>
            /// 医保总费用
            /// </summary>
            public System.Decimal? MedicalInsuranceAllAmount { get; set; }

            /// <summary>
            /// 医保住院号
            /// </summary>
            public System.String MedicalInsuranceHospitalizationNo { get; set; }

            /// <summary>
            /// 自付费用
            /// </summary>
            public System.Decimal? SelfPayFeeAmount { get; set; }

            /// <summary>
            /// 入院登记json
            /// </summary>
            public System.String AdmissionInfoJson { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public System.Decimal? ReimbursementExpensesAmount { get; set; }

            /// <summary>
            /// 其他信息
            /// </summary>
            public System.String OtherInfo { get; set; }

            /// <summary>
            /// 组织机构编码
            /// </summary>
            public System.String OrganizationCode { get; set; }

            /// <summary>
            /// 组织机构名称
            /// </summary>
            public System.String OrganizationName { get; set; }

            /// <summary>
            /// 结算订单号
            /// </summary>
            public System.String SettlementNo { get; set; }

            /// <summary>
            /// 交易id
            /// </summary>
            public System.String SettlementTransactionId { get; set; }

            /// <summary>
            /// 预结算交易id
            /// </summary>
            public System.String PreSettlementTransactionId { get; set; }

            /// <summary>
            /// 取消交易id
            /// </summary>
            public System.String CancelTransactionId { get; set; }

            /// <summary>
            /// 医保类型
            /// </summary>
            public System.Int64? InsuranceType { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public System.DateTime? CreateTime { get; set; }

            /// <summary>
            /// 更新标记
            /// </summary>
            public System.Byte[] Version { get; set; }

            /// <summary>
            /// 医保病人状态
            /// </summary>
            public System.Int32? MedicalInsuranceState { get; set; }

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
            /// 取消时间
            /// </summary>
            public System.DateTime? SettlementCancelTime { get; set; }

            /// <summary>
            /// 预结算时间
            /// </summary>
            public System.DateTime? PreSettlementTime { get; set; }

            /// <summary>
            /// 结算时间
            /// </summary>
            public System.DateTime? SettlementTime { get; set; }

            /// <summary>
            /// 操作员ID-[创建]
            /// </summary>
            public System.String CreateUserId { get; set; }

            /// <summary>
            /// 操作员ID-[删除]
            /// </summary>
            public System.String DeleteUserId { get; set; }

            /// <summary>
            /// 更新人员id
            /// </summary>
            public System.String UpdateUserId { get; set; }

            /// <summary>
            /// 结算人员
            /// </summary>
            public System.String SettlementUserId { get; set; }

            /// <summary>
            /// 取消人员
            /// </summary>
            public System.String SettlementCancelUserId { get; set; }

            /// <summary>
            /// 预结算人员id
            /// </summary>
            public System.String PreSettlementUserId { get; set; }

            /// <summary>
            /// 职工划卡信息
            /// </summary>
            public System.String WorkersStrokeCardInfo { get; set; }

            /// <summary>
            /// 职工划卡流水号
            /// </summary>
            public System.String WorkersStrokeCardNo { get; set; }

            /// <summary>
            /// 职工划卡时间
            /// </summary>
            public System.DateTime? WorkersStrokeTime { get; set; }

            /// <summary>
            /// 取消结算备注
            /// </summary>
            public System.String CancelSettlementRemarks { get; set; }

            /// <summary>
            /// 是否生育入院登记
            /// </summary>
            public System.Boolean? IsBirthHospital { get; set; }

            /// <summary>
            /// 身份标识
            /// </summary>
            public System.String IdentityMark { get; set; }

            /// <summary>
            /// 传入标志
            /// </summary>
            public System.String AfferentSign { get; set; }

            /// <summary>
            /// 结算类别 2 刷卡 3 电子凭证
            /// </summary>
            public System.String SettlementType { get; set; }

            /// <summary>
            /// 参保地区域编码
            /// </summary>
            public System.String AreaCode { get; set; }

            /// <summary>
            /// 出院时间
            /// </summary>
            public System.DateTime? LeaveHospitalTime { get; set; }

            /// <summary>
            /// 出院流水号
            /// </summary>
            public System.String LeaveHospitalSerialNumber { get; set; }
        }
    
}
