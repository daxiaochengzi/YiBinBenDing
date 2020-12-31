using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{/// <summary>
/// 
/// </summary>
   public class OutpatientExclusionParam
    {
       
    }
    /// <summary>
    /// 添加
    /// </summary>
    public class OutpatientExclusionAddParam
    {
        /// <summary>
        /// 目录名称
        /// </summary>
        public string DirectoryName { get; set; }
        /// <summary>
        /// 目录编码
        /// </summary>
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public string DirectoryCategoryName { get; set; }
        /// <summary>
        /// 目录编码
        /// </summary>
        public  UserInfoDto User { get; set; }
    }
    /// <summary>
    /// 查询
    /// </summary>
    public class OutpatientExclusionQueryParam: PaginationDto
    {/// <summary>
    /// 组织机构
    /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 目录名称
        /// </summary>
        public  string DirectoryName { get; set; }
    }
    /// <summary>
    /// 门诊取消不传医保
    /// </summary>
    public class OutpatientExclusionCancelParam
    {   /// <summary>
        /// 目录编码
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string UserId { get; set; }
    }
}
