using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Resident
{
   public class OrganizationInpatientDetailDto
    {/// <summary>
    /// 业务id
    /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 数据明细id
        /// </summary>
        public  string DetailId { get; set; }
        /// <summary>
        /// 上传标志
        /// </summary>
        public int  UploadMark { get; set; }
    }
}
