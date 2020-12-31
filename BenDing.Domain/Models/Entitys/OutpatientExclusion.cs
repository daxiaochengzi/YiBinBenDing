using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Entitys
{
   public class OutpatientExclusion
    { /// <summary>
        /// 
        /// </summary>
        public OutpatientExclusion()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Guid Id { get; set; }

        /// <summary>
        /// 目录编码
        /// </summary>
        public System.String DirectoryCode { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        public System.String DirectoryName { get; set; }

        /// <summary>
        /// 机构编码
        /// </summary>
        public System.String OrganizationCode { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public System.String OrganizationName { get; set; }
        /// <summary>
        /// 目录类别
        /// </summary>
        public System.String DirectoryCategoryName { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>
        public System.String CreateUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Byte[] Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public System.String CreateUserId { get; set; }

        /// <summary>
        /// 删除人员
        /// </summary>
        public System.String DeleteUserId { get; set; }
     

        /// <summary>
        /// 更新人员
        /// </summary>
        public System.String UpdateUserId { get; set; }
       
        

    }
}
