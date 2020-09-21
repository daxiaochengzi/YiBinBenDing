using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Data.IAbstractions;

namespace BenDing.Data.SqlServer
{
    /// <summary>
    /// Sql Server方言
    /// </summary>
    public class SqlServerDialect : IDialect
    {
        /// <summary>
        /// 获取安全名称
        /// </summary>
        public string SafeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;
            if (name == "*")
                return name;
            name = name.Trim().TrimStart('[').TrimEnd(']');
            return $"[{name}]";
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        public string GetPrefix()
        {
            return "@";
        }
    }
}
