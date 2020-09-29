using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Params.OutpatientDepartment
{
   public class WorkerHospitalSettlementCardParam
    { /// <summary>
        /// 卡密码
        /// </summary>
        public string CardPwd { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 划卡类别 1 门诊划卡2住院划卡
        /// </summary>
        public string UseCardType { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>

        public string OperatorName { get; set; }
        /// <summary>
        /// 医院医保编号
        /// </summary>

        public string HospitalLogNo { get; set; }
    }
}
