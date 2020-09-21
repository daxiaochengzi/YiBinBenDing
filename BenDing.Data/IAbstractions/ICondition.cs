using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Data.IAbstractions
{
    /// <summary>
    /// Sql查询条件
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// 获取查询条件
        /// </summary>
        string GetCondition();
    }
}
