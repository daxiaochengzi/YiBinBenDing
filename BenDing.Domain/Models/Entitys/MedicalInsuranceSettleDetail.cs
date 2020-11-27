using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Infrastructures;

namespace BenDing.Domain.Models.Entitys
{
    public class MedicalInsuranceSettleDetail: IBaseEntity<MedicalInsuranceSettleDetail>, IBaseDeleteAudited, IBaseCreationAudited, IBaseModificationAudited
    {
        /// <summary>
        /// 
        /// </summary>
        public MedicalInsuranceSettleDetail()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// HIS业务ID
        /// </summary>
        public System.String BusinessId { get; set; }

        /// <summary>
        /// 清算类别
        /// </summary>
        public System.String LiquidationType { get; set; }

        /// <summary>
        /// 结算编号
        /// </summary>
        public System.String SettlementNo { get; set; }

        /// <summary>
        /// 明细序号
        /// </summary>
        public System.Int32? SettlementOrder { get; set; }

        /// <summary>
        /// 明细类型(0.其他字符,1金额)
        /// </summary>
        public System.Int32? SettlementType { get; set; }

        /// <summary>
        /// 明细代码
        /// </summary>
        public System.String SettlementCode { get; set; }

        /// <summary>
        /// 明细英文名称
        /// </summary>
        public System.String SettlementEn { get; set; }

        /// <summary>
        /// 明细中文名称
        /// </summary>
        public System.String SettlementCh { get; set; }

        /// <summary>
        /// 明细内容
        /// </summary>
        public System.String SettlementVal { get; set; }

        /// <summary>
        /// 组织机构编码
        /// </summary>
        public System.String OrganizationCode { get; set; }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public System.String OrganizationName { get; set; }

        /// <summary>
        /// 申请流水号
        /// </summary>
        public System.String ApplicationSerialNumber { get; set; }

        /// <summary>
        /// 是否删除[0默认,1删除]
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Byte[] Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DeleteUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String UpdateUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String CreateUserId { get; set; }
    }
}
