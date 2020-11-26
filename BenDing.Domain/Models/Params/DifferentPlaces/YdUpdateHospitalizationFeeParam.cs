using System.Collections.Generic;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Params.DifferentPlaces
{/// <summary>
/// 
/// </summary>
  public  class YdUpdateHospitalizationFeeParam
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> IdList { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public bool IsDelete{ get; set; }
        /// <summary>
        /// 
        /// </summary>
       public UserInfoDto User { get; set; }
        /// <summary>
        /// 项目批次号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 交易Id
        /// </summary>
        public string TransactionId { get; set; }
    }
}
