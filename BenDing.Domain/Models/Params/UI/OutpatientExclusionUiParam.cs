using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class OutpatientExclusionUiParam
    {
       
    }
    public class OutpatientExclusionQueryUiParam : PaginationDto
    {/// <summary>
        /// 用户id
        /// </summary>
        [Display(Name = "用户id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]

        public string UserId { get; set; }
       
        /// <summary>
        /// 目录名称
        /// </summary>
        public string DirectoryName { get; set; }
    }
    public class OutpatientExclusionAddUiParam: UiInIParam
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
        /// 
        /// </summary>
        public string DirectoryCategoryName { get; set; }
    }

    public class OutpatientExclusionCancelUiParam : UiInIParam
    {
        /// <summary>
        ///id
        /// </summary>

        [Display(Name = "id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string Id { get; set; }
       
    }
}
