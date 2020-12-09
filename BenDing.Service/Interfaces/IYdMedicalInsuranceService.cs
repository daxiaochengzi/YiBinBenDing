using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.DifferentPlaces;
using BenDing.Domain.Models.Params.UI.DifferentPlaces;

namespace BenDing.Service.Interfaces
{
    public  interface IYdMedicalInsuranceService
    {/// <summary>
     /// 获取异地入院登记参数
     /// </summary>
     /// <param name="param"></param>
     /// <returns></returns>
        YdBaseParam GetYdHospitalizationRegisterParam(YdHospitalizationRegisterUiParam param);
        /// <summary>
        /// 异地入院登记
        /// </summary>
        /// <param name="param"></param>
        void YdHospitalizationRegister(YdHospitalizationRegisterUiParam param);
        /// <summary>
        /// 获取取消入院登记参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        YdBaseParam GetYdCancelHospitalizationRegisterParam(UiBaseDataParam param);
        /// <summary>
        /// 取消入院登记
        /// </summary>
        /// <param name="param"></param>
        void YdCancelHospitalizationRegister(UiBaseDataParam param);
        /// <summary>
        /// 获取出院办理参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        YdBaseParam GetYdLeaveHospitalParam(UiBaseDataParam param);
        /// <summary>
        /// 出院办理
        /// </summary>
        /// <param name="param"></param>
        void YdLeaveHospital(GetYdLeaveHospitalUiParam param);
        /// <summary>
        /// 获取取消出院办理参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        YdBaseParam GetYdCancelLeaveHospitalParam(UiBaseDataParam param);
        /// <summary>
        /// 取消出院办理
        /// </summary>
        /// <param name="param"></param>
        void YdCancelLeaveHospital(GetYdLeaveHospitalUiParam param);

        /// <summary>
        /// 获取异地处方上传参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetYdPrescriptionUploadParam GetYdPrescriptionUploadParam(GetYdPrescriptionUploadUiParam param);

        /// <summary>
        /// 异地处方上传
        /// </summary>
        /// <param name="param"></param>
        void YdPrescriptionUpload(GetYdPrescriptionUploadUiParam param);

        /// <summary>
        /// 获取异地取消处方上传参数
        /// </summary>
        /// <param name="param"></param>
        YdIdListBaseParam GetYdCancelPrescriptionUploadParam(GetYdCancelPrescriptionUploadUiParam param);

        /// <summary>
        /// 异地取消处方上传
        /// </summary>
        /// <param name="param"></param>
        void YdCancelPrescriptionUpload(GetYdCancelPrescriptionUploadUiParam param);
        /// <summary>
        /// 获取异地住院预结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        YdBaseParam GetYdHospitalizationPreSettlementParam(GetYdCancelPrescriptionUploadUiParam param);
        /// <summary>
        /// 异地住院预结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        SettlementDto YdHospitalizationPreSettlement(GetYdCancelPrescriptionUploadUiParam param);
        /// <summary>
        /// 获取异地住院结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         YdBaseParam GetYdHospitalizationSettlementParam(GetYdHospitalizationSettlementUiParam param);
        /// <summary>
        /// 异地住院结算
        /// </summary>
        /// <param name="param"></param>
        void YdHospitalizationSettlement(GetYdHospitalizationSettlementUiParam param);

        /// <summary>
        /// 获取取消异地结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        YdBaseParam GetYdCancelHospitalizationSettlementParam(GetYdHospitalizationSettlementUiParam param);

        /// <summary>
        /// 取消异地结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        void YdCancelHospitalizationSettlement(GetYdHospitalizationSettlementUiParam param);

        /// <summary>
        /// 获取异地门诊划卡参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        YdBaseParam GetYdOutpatientPayCardParam(GetYdOutpatientPayCardParam param);

        /// <summary>
        /// 异地门诊刷卡
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        WorkerHospitalSettlementCardBackDto YdOutpatientPayCard(GetYdOutpatientPayCardParam param);

    }
}
