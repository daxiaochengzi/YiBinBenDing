﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
  public  class SaveXmlDataUiParam
    {/// <summary>
        /// 入参
        /// </summary>
        [Display(Name = "入参")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(8000, ErrorMessage = "入参输入过长，不能超过8000位")]

        public string Participation { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        [Display(Name = "返回结果")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(8000, ErrorMessage = "返回结果输入过长，不能超过8000位")]
        public string ResultData { get; set; }
        /// <summary>
        /// 医保返回的业务号
        /// </summary>
        ///
        [Display(Name = "医保返回的业务号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "医保返回的业务号输入过长，不能超过32位")]
        public string BusinessNumber { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(18, ErrorMessage = "身份证号输入过长，不能超过18位")]
        public string IDCard { get; set; }

        public  string Remark { get; set; }
    }
}
