using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.UI
{
  public  class MedicalDirectoryCodeUiParam
    {/// <summary>
    /// 用户id
    /// </summary>
        public string EmpId { get; set; }
        /// <summary>
        /// 初始化商品名称
        /// </summary>
        public string InIDirectoryName { get; set; }
        /// <summary>
        /// 初始化商品编码
        /// </summary>
        public string InIDirectoryCode { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
       
        public  string InIProjectCodeType { get; set; }
    }
}
