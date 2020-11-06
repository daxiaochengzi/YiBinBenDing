﻿using BenDing.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Data.IAbstractions
{
    /// <summary>
    /// 参数管理器
    /// </summary>
    public interface IParameterManager
    {
        /// <summary>
        /// 创建参数名
        /// </summary>
        string GenerateName();
        /// <summary>
        /// 获取参数列表
        /// </summary>
        IDictionary<string, object> GetParams();
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="operator">运算符</param>
        void Add(string name, object value, Operator? @operator = null);
    }
}