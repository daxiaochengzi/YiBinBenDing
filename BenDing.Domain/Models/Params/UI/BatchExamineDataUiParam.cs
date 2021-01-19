using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class BatchExamineDataUiParam: BaseUiBusinessIdDataParam
    {/// <summary>
     /// 审核标记 0未审核1审核通过2审核不通过
     /// </summary>
        public int BatchExamineSign { get; set; }
    }
}
