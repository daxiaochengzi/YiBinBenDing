using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;

namespace BenDing.Domain.Models.Params.Web
{
   public class QueryCatalogUiParam: PaginationDto
    {/// <summary>
     /// 目录编码
     /// </summary>
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 目录名称
        /// </summary>

        public string DirectoryName { get; set; }
        /// <summary>
        /// 目录类别
        /// </summary>
        public string DirectoryCategoryCode { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string ManufacturerName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        [Display(Name = "用户id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string UserId { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>

        public  string OrganizationCode { get; set; }


    }
}
