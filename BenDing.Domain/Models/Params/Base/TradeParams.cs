using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BenDing.Domain.Models.Params.Base
{
 
    public class TradeParams
    {
        public const string XmlHead = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>";
        /// <summary>
        /// 交易编号
        /// </summary>
        public string TradeId;
        /// <summary>
        /// 入参
        /// </summary>
        public string InData;
        /// <summary>
        /// 出参
        /// </summary>
        public string OutData;

        /// <summary>
        /// 输入参数集合
        /// </summary>
        public Dictionary<string, string> Items { get; set; }
        /// <summary>
        /// 输出参数集合
        /// </summary>
        public Dictionary<string, string> OutItems { get; set; }
        /// <summary>
        /// 输入参数名称集合，按顺序
        /// </summary>
        public List<string> Keys { get; set; }
        /// <summary>
        /// 输出参数名称集合，按顺序
        /// </summary>
        public List<string> OutKeys { get; set; }
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string this[string name]
        {
            set
            {
                name = name.ToLower();
                if (Items.ContainsKey(name))
                {
                    Items[name] = value;
                }
                else
                {
                    Items.Add(name, value);
                    if (!Keys.Contains(name))
                    {
                        Keys.Add(name);
                    }
                }
            }
            get
            {
                name = name.ToLower();
                return OutItems.ContainsKey(name) ? OutItems[name] : "";
            }
        }
        /// <summary>
        /// 交易入参
        /// </summary>
        public string XmlIn
        {
            get
            {
                var xmlin = XmlHead + "<data>";
                foreach (var item in Keys)
                {
                    xmlin += string.Format("<{0}>{1}</{0}>", item, Items[item]);
                }
                xmlin = xmlin + "</data>";
                return xmlin;
            }
        }
        /// <summary>
        /// 交易控制
        /// </summary>
        public string XmlCtr
        {
            get
            {
                if (Items.Count == 0)
                {
                    return XmlHead + "<control></control>";
                }
                var xmlin = XmlHead + "<control>";
                foreach (var item in Keys)
                {
                    xmlin += string.Format("<{0}>{1}</{0}>", item, Items[item]);
                }
                xmlin = xmlin + "</control>";
                return xmlin;
            }
        }
        public TradeParams(string tradeId)
        {
            Items = new Dictionary<string, string>();
            OutItems = new Dictionary<string, string>();
            Keys = new List<string>();
            OutKeys = new List<string>();
            this.TradeId = tradeId;
            this.OutData = string.Empty.PadRight(3000);
        }

        public void parseout()
        {
            try
            {
                var xmldom = new XmlDocument();
                xmldom.LoadXml(OutData);
                foreach (XmlNode item in xmldom.SelectSingleNode("/output").ChildNodes)
                {
                    OutItems.Add(item.Name.ToLower(), item.InnerText);
                    OutKeys.Add(item.Name.ToLower());
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 获取XML节点值
        /// </summary>
        /// <param name="tradeMsg">xml</param>
        /// <param name="tradeType">根节点</param>
        /// <param name="nodeName">子节点</param>
        /// <returns></returns>
        public string GetNoteValue(string tradeMsg, string tradeType, string nodeName)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(tradeMsg);
            XmlNode xn;
            string tragetField = string.Empty;
            try
            {
                xn = xd.SelectSingleNode("//" + tradeType).SelectSingleNode(nodeName);
                tragetField = xn.InnerText.Trim();
                return tragetField;
            }
            catch
            {
                return "";
            }
        }
    }
}
