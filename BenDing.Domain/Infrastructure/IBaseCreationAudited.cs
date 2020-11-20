using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Infrastructure
{
    public interface IBaseCreationAudited
    {
        Guid Id { get; set; }
        string CreateUserId { get; set; }
        DateTime? CreateTime { get; set; }
        string OrganizationCode { get; set; }
        string OrganizationName { get; set; }
    }
}
