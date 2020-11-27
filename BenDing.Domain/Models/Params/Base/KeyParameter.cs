using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.Base
{
    public class KeyParameter
    {
        /// <summary>
        /// 通过键获取值，自动转换为大写
        /// </summary>
        /// <param name="key">键的名称</param>
        /// <returns></returns>
        public string this[string key]
        {
            get { key = key.ToLower().Trim(); return Items.ContainsKey(key.ToLower()) ? Items[key] : string.Empty; }
            set
            {
                key = key.ToLower();
                if (Items.ContainsKey(key))
                {
                    Items[key] = value;
                }
                else
                {
                    Items.Add(key, value);
                }
            }
        }
        public string Value { get; set; }
        public Dictionary<string, string> Items { get; set; }

        public KeyParameter()
        {
            Items = new Dictionary<string, string>();
        }

        /// <summary>
        /// 键值对参数
        /// </summary>
        /// <param name="value">包含键值对的字符串</param>
        /// <param name="separator">分隔符</param>
        public KeyParameter(string value, char separator = '|')
        {
            Value = value;
            Items = new Dictionary<string, string>();
            foreach (var item in value.Split(separator))
            {
                var kv = item.Split('=');
                if (kv.Length > 1)
                {
                    this[kv[0]] = kv[1];
                }
            }
        }

    }
}
