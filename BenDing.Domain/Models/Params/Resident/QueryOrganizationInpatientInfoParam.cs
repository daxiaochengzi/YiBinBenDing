using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Base;

namespace BenDing.Domain.Models.Params.Resident
{
   public class QueryOrganizationInpatientInfoParam:PaginationDto
    {/// <summary>
    /// 组织机构
    /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 查询关键字
        /// </summary>
        public  string SearchKey { get; set; }

    }
}
