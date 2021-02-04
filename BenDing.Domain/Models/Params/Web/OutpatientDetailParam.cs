using System;
using System.Collections.Generic;
using System.Text;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.Base;
using Newtonsoft.Json;

namespace BenDing.Domain.Models.Params.Web
{
    /// <summary>
    /// 获取门诊病人明细
    /// </summary>
  public  class OutpatientDetailParam
    {
        /// <summary>
        /// 
        /// </summary>
        public UserInfoDto User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string  Id { get; set; }
        /// <summary>
        /// 是否保存
        /// </summary>
        public bool IsSave { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 不传标记
        /// </summary>
        public int? NotUploadMark { get; set; }
        /// <summary>
        /// 病人id
        /// </summary>
        public string PatientId { get; set; }
    }
}
