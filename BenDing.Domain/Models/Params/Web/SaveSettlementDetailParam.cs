using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.Web
{
   public class SaveSettlementDetailParam
    {/// <summary>
        /// 结算类型  1 门诊,2 门特 3 住院
        /// </summary>
        public int SettlementType { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 结算编号
        /// </summary>
        public string SettlementNo { get; set; }
        /// <summary>
        /// 输出xml
        /// </summary>
        public string OutputXml { get; set; }
        /// <summary>
        /// 清算类别
        /// </summary>
        public string LiquidationType { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public UserInfoDto User { get; set; }
    }
}
