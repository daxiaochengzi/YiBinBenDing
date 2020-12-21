using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.JsonEntity;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.Workers;
using BenDing.Domain.Models.Params.OutpatientDepartment;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.Web;

namespace BenDing.Service.Interfaces
{/// <summary>
/// 门诊插件模式
/// </summary>
    public  interface IOutpatientDepartmentNewService
    {  /// <summary>
       /// 获取普通门诊结算入参
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
        OutpatientDepartmentCostInputParam GetOutpatientDepartmentCostInputParam(GetOutpatientPersonParam param);
        /// <summary>
        /// 门诊结算录入
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        OutpatientDepartmentCostInputDto OutpatientDepartmentCostInput(GetOutpatientPersonParam param);
        /// <summary>
        /// 获取取消结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string GetCancelOutpatientDepartmentCostParam(CancelOutpatientDepartmentCostUiParam param);
        /// <summary>
        /// 门诊取消结算
        /// </summary>
        /// <param name="param"></param>
        void CancelOutpatientDepartmentCost(CancelOutpatientDepartmentCostUiParam param);
        /// <summary>
        /// 获取门诊计划生育预结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <returns></returns>
        OutpatientPlanBirthPreSettlementParam GetOutpatientPlanBirthPreSettlementParam(
            OutpatientPlanBirthPreSettlementUiParam param
        );
        /// <summary>
        /// 获取门诊计划生育结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <returns></returns>
        OutpatientPlanBirthSettlementParam GetOutpatientPlanBirthSettlementParam(
            OutpatientPlanBirthSettlementUiParam param);
        /// <summary>
        /// 门诊计划生育预结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        WorkerBirthSettlementDto OutpatientPlanBirthPreSettlement(
            OutpatientPlanBirthPreSettlementUiParam param);
        /// <summary>
        /// 门诊计划生育结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        WorkerBirthSettlementDto OutpatientPlanBirthSettlement(
            OutpatientPlanBirthSettlementUiParam param);
        /// <summary>
        /// 获取门诊月结入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MonthlyHospitalizationParam GetMonthlyHospitalizationParam(MonthlyHospitalizationUiParam param);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MonthlyHospitalizationCancelParam GetMonthlyHospitalizationCancelUiParam(
            GetMonthlyHospitalizationCancelUiParam param);
        /// <summary>
        /// 门诊月结
        /// </summary>
        /// <param name="param"></param>
        void MonthlyHospitalization(MonthlyHospitalizationUiParam param);
        /// <summary>
        /// 获取门诊电子卡参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string OutpatientNationEcTransParam(OutpatientNationEcTransUiParam param);
        /// <summary>
        /// 电子医保支付
        /// </summary>
        /// <param name="param"></param>
        NationEcTransDto OutpatientNationEcTrans(OutpatientNationEcTransUiParam param);
        /// <summary>
        /// 居民电子凭证支付参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string GetOutpatientNationEcTransResidentParam(OutpatientNationEcTransUiParam param);
        /// <summary>
        /// 居民电子凭证支付
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        OutpatientNationEcTransResidentBackDto OutpatientNationEcTransResident(OutpatientNationEcTransUiParam param);
        /// <summary>
        /// 获取划卡参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        WorkerHospitalSettlementCardParam WorkerOutpatientSettlementCardParam(
            WorkerHospitalSettlementCardUiParam param);
        /// <summary>
        /// 门诊划卡
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         WorkerHospitalSettlementCardBackDto WorkerOutpatientSettlementCard(
            WorkerHospitalSettlementCardUiParam param);
        /// <summary>
        /// 获取门诊居民预结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string GetResidentOutpatientPreSettlementParam(GetResidentOutpatientSettlementUiParam param);
        /// <summary>
        /// 普通居民预结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         OutpatientNationEcTransResidentBackDto ResidentOutpatientPreSettlement(
            GetResidentOutpatientSettlementUiParam param);
        /// <summary>
        /// 获取门诊划卡参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string ResidentOutpatientSettlementCardParam(
            GetResidentOutpatientSettlementCardUiParam param);
        /// <summary>
        /// 门诊居民划卡
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        OutpatientNationEcTransResidentBackDto ResidentOutpatientSettlementCard(
            GetResidentOutpatientSettlementCardUiParam param);
        /// <summary>
        /// 门诊居民确认结算
        /// </summary>
        /// <param name="param"></param>
         void OutpatientResidentConfirmSettlement(OutpatientResidentConfirmSettlementUiParam param);


    }
}
