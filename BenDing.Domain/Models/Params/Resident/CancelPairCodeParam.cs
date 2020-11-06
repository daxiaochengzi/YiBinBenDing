using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.UI;

namespace BenDing.Domain.Models.Params.Resident
{
  public  class CancelPairCodeParam: UiInIParam
    {/// <summary>
    /// 对码表id
    /// </summary>
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 医保项目名称
        /// </summary>
        public  string ProjectName { get; set; }
    }
}
