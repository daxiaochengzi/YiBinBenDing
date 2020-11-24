﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{
   public class GetYdPrescriptionUploadUiParam: UiInIParam
    {
        /// <summary>
        /// 根据病人业务id上传
        /// </summary>
        [Display(Name = "业务id")]

        public string BusinessId { get; set; }

        /// <summary>
        /// 根据数据id上传
        /// </summary>
        public List<string> DataIdList { get; set; } = null;
        /// <summary>
        /// 结算json
        /// </summary>
        public string SettlementJson { get; set; }
    }
}
