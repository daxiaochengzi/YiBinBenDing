using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.Resident
{
   public class QueryOrganizationInpatientInfoUiParam: QueryOrganizationInpatientInfoParam
    {
        public string UserId { get; set; }
    }
}
