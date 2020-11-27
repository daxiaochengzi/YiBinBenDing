using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Xml
{
   public class MappingInfo
    {   //门诊结算明细
        public static Dictionary<string, string[]> FeiyongTypeMZ = new Dictionary<string, string[]>();
        ////门特结算明细
        //public static Dictionary<string, string[]> FeiyongTypeMZMT = new Dictionary<string, string[]>();
        //住院结算明细
        public static Dictionary<string, string[]> FeiyongTypeZY = new Dictionary<string, string[]>();

        static MappingInfo()
        {
            FeiyongTypeMZ.Add("akc190", new string[] { "0", "akc190", "就诊编码" });
            FeiyongTypeMZ.Add("aka130", new string[] { "0", "aka130", "支付类别" });
            FeiyongTypeMZ.Add("ykd007", new string[] { "0", "ykd007", "报销类型" });
            FeiyongTypeMZ.Add("aac001", new string[] { "0", "aac001", "个人编码" });
            FeiyongTypeMZ.Add("akb020", new string[] { "0", "akb020", "医院编码" });
            FeiyongTypeMZ.Add("aae011", new string[] { "0", "aae011", "经办人姓名" });
            FeiyongTypeMZ.Add("aae036", new string[] { "0", "aae036", "经办时间" });
            FeiyongTypeMZ.Add("yka103", new string[] { "0", "yka103", "结算编号" });
            FeiyongTypeMZ.Add("yka055", new string[] { "0", "yka055", "费用总额" });
            FeiyongTypeMZ.Add("yka056", new string[] { "0", "yka056", "全自费" });
            FeiyongTypeMZ.Add("yka111", new string[] { "0", "yka111", "符合范围" });
            FeiyongTypeMZ.Add("yka057", new string[] { "0", "yka057", "挂钩自付" });
            FeiyongTypeMZ.Add("yka065", new string[] { "0", "yka065", "个人帐户支付总额" });
            FeiyongTypeMZ.Add("yka107", new string[] { "0", "yka107", "社保基金支付总额" });
            FeiyongTypeMZ.Add("ykh012", new string[] { "0", "ykh012", "现金及其他自付" });
            FeiyongTypeMZ.Add("yab003", new string[] { "0", "yab003", "医保经办机构" });
            //医保节点 /output/dataset/row
            FeiyongTypeMZ.Add("yab139", new string[] { "1", "yab139", "参保所属分中心" });
            FeiyongTypeMZ.Add("aka213", new string[] { "1", "aka213", "费用分段标准" });
            FeiyongTypeMZ.Add("yka115", new string[] { "1", "yka115", "起付线" });
            FeiyongTypeMZ.Add("yka058", new string[] { "1", "yka058", "进入起付线部份" });
            FeiyongTypeMZ.Add("ykc125", new string[] { "1", "ykc125", "报销比例" });
            FeiyongTypeMZ.Add("ykc121", new string[] { "1", "ykc121", "就诊结算方式" });
            FeiyongTypeMZ.Add("ykb037", new string[] { "1", "ykb037", "清算分中心" });
            FeiyongTypeMZ.Add("yka054", new string[] { "1", "yka054", "清算方式" });
            FeiyongTypeMZ.Add("yka316", new string[] { "1", "yka316", "清算类别" });
            ////门特结算
            //FeiyongTypeMZMT.Add("akc190", new string[] { "0", "akc190", "就诊编码" });
            //FeiyongTypeMZMT.Add("yka103", new string[] { "0", "yka103", "结算编号" });
            //FeiyongTypeMZMT.Add("aka130", new string[] { "0", "aka130", "支付类别" });
            //FeiyongTypeMZMT.Add("ykd007", new string[] { "0", "ykd007", "报销类型" });
            //FeiyongTypeMZMT.Add("aac001", new string[] { "0", "aac001", "个人编码" });
            //FeiyongTypeMZMT.Add("akb020", new string[] { "0", "akb020", "医院编码" });
            //FeiyongTypeMZMT.Add("aae011", new string[] { "0", "aae011", "经办人姓名" });
            //FeiyongTypeMZMT.Add("aae036", new string[] { "0", "aae036", "经办时间" });
            //FeiyongTypeMZMT.Add("yka055", new string[] { "0", "yka055", "费用总额" });
            //FeiyongTypeMZMT.Add("yka056", new string[] { "0", "yka056", "全自费" });
            //FeiyongTypeMZMT.Add("yka111", new string[] { "0", "yka111", "符合范围" });
            //FeiyongTypeMZMT.Add("yka057", new string[] { "0", "yka057", "挂钩自付" });
            //FeiyongTypeMZMT.Add("ykc177", new string[] { "0", "ykc177", "帐户余额" });
            //FeiyongTypeMZMT.Add("yka107", new string[] { "0", "yka107", "社保基金支付总额" });
            //FeiyongTypeMZMT.Add("yka065", new string[] { "0", "yka065", "个人帐户支付总额" });
            //FeiyongTypeMZMT.Add("yka719", new string[] { "0", "yka719", "个人账户共济标志" });
            //FeiyongTypeMZMT.Add("ykh012", new string[] { "0", "ykh012", "现金及其他自付" });
            //FeiyongTypeMZMT.Add("yab003", new string[] { "0", "yab003", "医保经办机构" });
            //医保节点 /output/dataset/row
            //FeiyongTypeMZMT.Add("yab139", new string[] { "1", "yab139", "参保所属分中心" });
            //FeiyongTypeMZMT.Add("aka213", new string[] { "1", "aka213", "费用分段标准" });
            //FeiyongTypeMZMT.Add("yka115", new string[] { "1", "yka115", "起付线" });
            //FeiyongTypeMZMT.Add("yka058", new string[] { "1", "yka058", "进入起付线部份" });
            //FeiyongTypeMZMT.Add("ykc125", new string[] { "1", "ykc125", "报销比例" });
            //FeiyongTypeMZMT.Add("ykc121", new string[] { "1", "ykc121", "就诊结算方式" });
            //FeiyongTypeMZMT.Add("ykb037", new string[] { "1", "ykb037", "清算分中心" });
            //FeiyongTypeMZMT.Add("yka054", new string[] { "1", "yka054", "清算方式" });
            //FeiyongTypeMZMT.Add("yka316", new string[] { "1", "yka316", "清算类别" });

            //住院结算
            FeiyongTypeZY.Add("po_sybxzf", new string[] { "0", "po_sybxzf", "生育保险支付" });
            FeiyongTypeZY.Add("po_bxsdyyy", new string[] { "0", "po_bxsdyyy", "不享受待遇原因" });
            FeiyongTypeZY.Add("po_gwyzf", new string[] { "0", "po_gwyzf", "公务员支付" });
            FeiyongTypeZY.Add("po_xnhzf", new string[] { "0", "po_xnhzf", "新农合支付" });
            FeiyongTypeZY.Add("po_qtxzzf", new string[] { "0", "po_qtxzzf", "基它险种支付" });
            FeiyongTypeZY.Add("po_djh", new string[] { "0", "po_djh", "结算单据号" });
            FeiyongTypeZY.Add("po_jmtczf", new string[] { "0", "po_jmtczf", "居民统筹支付" });
            FeiyongTypeZY.Add("po_xzlx", new string[] { "0", "po_xzlx", "险种" });
            FeiyongTypeZY.Add("po_xsdybs", new string[] { "0", "po_xsdybs", "享受待遇标识" });
            FeiyongTypeZY.Add("po_cxjzf", new string[] { "0", "po_cxjzf", "超限价自付" });
            FeiyongTypeZY.Add("po_jshzhye", new string[] { "0", "po_jshzhye", "结算后账户余额" });
            FeiyongTypeZY.Add("po_fyze", new string[] { "0", "po_fyze", "费用总额" });
            FeiyongTypeZY.Add("po_tczf", new string[] { "0", "po_tczf", "基本统筹支付" });
            FeiyongTypeZY.Add("po_qfje", new string[] { "0", "po_qfje", "起付金额" });
            FeiyongTypeZY.Add("po_xjzf", new string[] { "0", "po_xjzf", "现金支付" });
            FeiyongTypeZY.Add("po_zhzf", new string[] { "0", "po_zhzf", "账户支付" });
            FeiyongTypeZY.Add("po_xzfje", new string[] { "0", "po_xzfje", "先自付金额" });
            FeiyongTypeZY.Add("po_czfje", new string[] { "0", "po_czfje", "纯自费金额" });
            FeiyongTypeZY.Add("po_bxqksm", new string[] { "0", "po_bxqksm", "报销情况说明" });
            FeiyongTypeZY.Add("po_jrbxje", new string[] { "0", "po_jrbxje", "进入报销范围金额" });
            FeiyongTypeZY.Add("po_sbzfhj", new string[] { "0", "po_sbzfhj", "社保支付合计" });
            FeiyongTypeZY.Add("po_bcylzf", new string[] { "0", "po_bcylzf", "补充医疗保险支付" });
            FeiyongTypeZY.Add("po_jmdbzf", new string[] { "0", "po_jmdbzf", "居民大病保险支付" });
            FeiyongTypeZY.Add("bka015", new string[] { "0", "bka015", "清算类别" });
            FeiyongTypeZY.Add("po_jylsh", new string[] { "0", "po_jylsh", "交易流水号" });
           

            ////医保节点 /output/dataset/row
            //FeiyongTypeZY.Add("yab139", new string[] { "1", "yab139", "参保所属分中心" });
            //FeiyongTypeZY.Add("aka213", new string[] { "1", "aka213", "费用分段标准" });
            //FeiyongTypeZY.Add("yka115", new string[] { "1", "yka115", "起付线" });
            //FeiyongTypeZY.Add("yka058", new string[] { "1", "yka058", "进入起付线部份" });
            //FeiyongTypeZY.Add("ykc125", new string[] { "1", "ykc125", "报销比例" });
            //FeiyongTypeZY.Add("ykc121", new string[] { "1", "ykc121", "就诊结算方式" });
            //FeiyongTypeZY.Add("ykb037", new string[] { "1", "ykb037", "清算分中心" });
            //FeiyongTypeZY.Add("yka054", new string[] { "1", "yka054", "清算方式" });
            //FeiyongTypeZY.Add("yka316", new string[] { "1", "yka316", "清算类别" });
        }
    }
}
