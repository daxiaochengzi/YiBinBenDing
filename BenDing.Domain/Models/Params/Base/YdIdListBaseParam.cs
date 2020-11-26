using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.Base
{/// <summary>
/// 
/// </summary>
   public class YdIdListBaseParam: YdBaseParam
    {
        public List<string> IdList { get; set; }
    }
}
