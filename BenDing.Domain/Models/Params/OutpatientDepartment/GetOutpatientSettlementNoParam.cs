using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
   public class GetOutpatientSettlementNoParam
    {
        public UserInfoDto User { get; set; }
        public string BusinessId { get; set; }
    }
}
