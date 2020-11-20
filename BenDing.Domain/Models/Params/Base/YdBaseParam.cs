using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.Base
{
   public class YdBaseParam
    {
        /// <summary>
        /// 交易码
        /// </summary>
        public string TransactionCode { get; set; }
        /// <summary>
        /// 入参xml
        /// </summary>
        public  string InputXml { get; set; }
    }
}
