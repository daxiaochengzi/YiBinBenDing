using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.Resident
{
   public class BatchExamineDataParam
    {/// <summary>
    /// 用户
    /// </summary>
        public UserInfoDto User { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>

      

        public string BusinessId { get; set; }
        /// <summary>
        /// 审核标记
        /// </summary>
        public int BatchExamineSign { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public List<string> DataIdList { get; set; } = null;
    }
}
