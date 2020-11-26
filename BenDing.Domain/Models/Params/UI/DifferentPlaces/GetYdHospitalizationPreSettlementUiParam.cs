using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{
   public class GetYdHospitalizationPreSettlementUiParam: UiBaseDataParam
    {     /// <summary>
        /// 结算json
        /// </summary>
        public string SettlementJson { get; set; }
    }
}
