using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Entitys
{
    /// <summary>
    /// Hospital医保日志表
    /// </summary>
    public class HospitalLog
    {
        /// <summary>
        /// Hospital医保日志表
        /// </summary>
        public HospitalLog()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 业务id
        /// </summary>
        public System.Guid? RelationId { get; set; }

        /// <summary>
        /// 入参或者旧数据
        /// </summary>
        public System.String JoinOrOldJson { get; set; }

        /// <summary>
        /// 回参或者新数据
        /// </summary>
        public System.String ReturnOrNewJson { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public System.String Remark { get; set; }

        /// <summary>
        /// 组织机构
        /// </summary>
        public System.String OrganizationCode { get; set; }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public System.String OrganizationName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新标记
        /// </summary>
        public System.Byte[] Version { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public System.String CreateUserId { get; set; }

        /// <summary>
        /// 更新人员
        /// </summary>
        public System.String UpdateUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String DeleteUserId { get; set; }
    }
}

