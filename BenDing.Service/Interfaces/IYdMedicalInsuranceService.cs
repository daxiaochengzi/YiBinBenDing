using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.UI.DifferentPlaces;

namespace BenDing.Service.Interfaces
{
  public  interface IYdMedicalInsuranceService
  {/// <summary>
  /// 获取门诊异地刷卡参数
  /// </summary>
  /// <param name="param"></param>
  /// <returns></returns>
      YdBaseParam GetYdOutpatientPayCardParam(GetYdOutpatientPayCardParam param);
        /// <summary>
        /// 异地刷卡
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
      WorkerHospitalSettlementCardBackDto YdOutpatientPayCard(GetYdOutpatientPayCardParam param);
  }
}
