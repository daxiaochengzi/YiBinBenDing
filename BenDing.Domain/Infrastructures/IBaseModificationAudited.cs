using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Infrastructures
{
    public interface IBaseModificationAudited
    {
        Guid Id { get; set; }
        string UpdateUserId { get; set; }
        DateTime? UpdateTime { get; set; }
    }
}
