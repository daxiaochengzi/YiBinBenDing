using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.Resident
{/// <summary>
/// 
/// </summary>
   public class PrescriptionUploadAutomaticParam
    {/// <summary>
    /// 是否当日上传
    /// </summary>
       public Boolean IsTodayUpload { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
       public  string OrganizationCode { get; set; }

    }
}
