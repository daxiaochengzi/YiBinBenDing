using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{
   public class DoctorAdvicePageUiParam: PaginationDto
    {/// <summary>
        /// 用户id
        /// </summary>
        [Display(Name = "用户id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]

        public string UserId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        [Display(Name = "业务id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string BusinessId { get; set; }

        /// <summary>
        /// 医保交易码
        /// </summary>
        [Display(Name = "医保交易码")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string TransKey { get; set; }
        /// <summary>
        /// 是否上传
        /// </summary>
        public int? DoctorAdviceUploadMark { get; set; }
    }
}
