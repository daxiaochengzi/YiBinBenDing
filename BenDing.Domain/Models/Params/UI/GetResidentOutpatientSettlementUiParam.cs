﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class GetResidentOutpatientSettlementUiParam: UiBaseDataParam
    {/// <summary>
    /// 密码
    /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public string AfferentSign { get; set; }
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string IdentityMark { get; set; }
        /// <summary>
        /// 保险类别
        /// </summary>
        public  string InsuranceType { get; set; }
        public  string SettlementJson { get; set; }
    }
}