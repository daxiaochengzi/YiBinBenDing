using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class WorkerHospitalSettlementCardBackDataDto
    {/// <summary>
        /// 流水号
        /// </summary>

       
        public string SerialNumber { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
     
        public decimal AccountPayment { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        
        public decimal CashPayment { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
       
        public decimal AccountBalance { get; set; }
    }
}
