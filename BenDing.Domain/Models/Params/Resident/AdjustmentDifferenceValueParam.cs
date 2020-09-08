using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.Resident
{
   public class AdjustmentDifferenceValueParam
    {
        public string Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public  string Amount { get; set; }
        /// <summary>
        ///数量
        /// </summary>

        public  string Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string UnitPrice { get; set; }
        ///// <summary>
        ///// 医保类别 西药费
        ///// </summary>
        //public string ProjectCodeType { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>

        public string BusinessId { get; set; }

    }
}
