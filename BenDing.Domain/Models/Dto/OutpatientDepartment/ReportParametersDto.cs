using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
    /// <summary>
    /// 报表参数
    /// </summary>
  public  class ReportParametersDto
    {/// <summary>
    /// 关键字
    /// </summary>
        public string Key { get; set; }
        /// <summary>
        ///值
        /// </summary>
        public string Value { get; set; }
    }
}
