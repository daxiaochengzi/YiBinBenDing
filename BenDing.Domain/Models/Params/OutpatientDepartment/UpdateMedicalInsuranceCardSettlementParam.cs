using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
   public class UpdateMedicalInsuranceCardSettlementParam
    {
        public string UserId { get; set; }
        /// <summary>
        /// 划卡信息
        /// </summary>
        public string WorkersStrokeCardInfo { get; set; }
        /// <summary>
        /// 划卡流水号
        /// </summary>
        public string WorkersStrokeCardNo { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public  string BusinessId { get; set; }
    } 
}
