﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.Params.DifferentPlaces
{
  public  class DifferentPlacesIsBackQueryParam
    {
     
        /// <summary>
        /// 参保地统筹区编号
        /// </summary>
        public string baa008 { get; set; }
        /// <summary>
        /// 查询类型代码
        /// </summary>
        public string cxlx { get; set; }
        /// <summary>
        /// 就诊登记号
        /// </summary>
        public string aaz217 { get; set; }
        /// <summary>
        /// 人员医疗结算事件id(就诊结算id)
        /// </summary>
        public string aaz216 { get; set; }
        /// <summary>
        /// 个人编号
        /// </summary>
        public string aac001 { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string aac003 { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string aac002 { get; set; }
    }
}
