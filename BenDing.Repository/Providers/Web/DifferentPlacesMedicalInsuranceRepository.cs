using System;
using BenDing.Domain.Models.DifferentPlacesXml.HospitalizationRegister;
using BenDing.Domain.Models.DifferentPlacesXml.LeaveHospital;
using BenDing.Domain.Models.Dto.DifferentPlaces;
using BenDing.Domain.Models.Dto.JsonEntity.DifferentPlaces;
using BenDing.Domain.Models.Dto.Resident;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.DifferentPlaces;
using BenDing.Domain.Models.Params.Resident;
using BenDing.Domain.Xml;

namespace BenDing.Repository.Providers.Web
{/// <summary>
/// 异地
/// </summary>
  public  class DifferentPlacesMedicalInsuranceRepository
    {
        /// <summary>
        /// 获取异地个人基础资料
        /// </summary>
        /// <param name="param"></param>
        public DifferentPlacesUserInfoDto DifferentPlacesGetUserInfo(YdGetUserInfoParam param)
        {
            DifferentPlacesUserInfoDto resultData = null;
            var xmlStr = XmlHelp.SaveXml(param);
            if (!xmlStr) throw new Exception("异地获取个人基础资料保存参数出错");
            MedicalInsuranceDll.CallService_cxjb("YYJK001");
            var data = XmlHelp.DeSerializerModel(new YdUserInfoJsonDto(), true);
            resultData = AutoMapper.Mapper.Map<DifferentPlacesUserInfoDto>(data);
            return resultData;
        }
        /// <summary>
        /// 异地入院登记
        /// </summary>
        /// <returns></returns>
        public DifferentPlacesHospitalizationRegisterDto DifferentPlacesHospitalizationRegister(YdHospitalizationRegisterCanCelParam param)
        {
            DifferentPlacesHospitalizationRegisterDto resultData = null;
            var xmlStr = XmlHelp.SaveXml(param);
            if (!xmlStr) throw new Exception("异地入院登记保存参数出错");
            int result = MedicalInsuranceDll.CallService_cxjb("YYJK003");
            if (result != 1) throw new Exception("异地医保执行出错!!!");
            var data = XmlHelp.DeSerializerModel(new YdHospitalizationRegisterJsonDto(), true);
            resultData = AutoMapper.Mapper.Map<DifferentPlacesHospitalizationRegisterDto>(data);
            return resultData;
        }
        /// <summary>
        /// 取消异地入院登记
        /// </summary>
        /// <returns></returns>
        public  CanCelDifferentPlacesHospitalizationRegisterDto CanCelDifferentPlacesHospitalizationRegister(YdHospitalizationRegisterParam param)
        {
           var resultData=new CanCelDifferentPlacesHospitalizationRegisterDto(); 
            var xmlStr = XmlHelp.SaveXml(param);
            if (!xmlStr) throw new Exception("取消异地入院登记保存参数出错");
            int result = MedicalInsuranceDll.CallService_cxjb("YYJK003");
            if (result != 1) throw new Exception("取消异地医保执行出错!!!");
            var data = XmlHelp.DeSerializerModel(new YdHospitalizationRegisterCancelJsonDto(), true);
            if (data != null) resultData.OperationTime = data.OperationTime; 
            return resultData;
        }
        /// <summary>
        /// 修改异地入院登记
        /// </summary>
        /// <param name="param"></param>
        public void ModifyDifferentPlacesHospitalization(ModifyDifferentPlacesHospitalizationParam param)
        {
            var xmlStr = XmlHelp.SaveXml(param);
            if (!xmlStr) throw new Exception("异地修改入院登记保存参数出错");
            int result = MedicalInsuranceDll.CallService_cxjb("CXJB003");
            if (result != 1) throw new Exception("异地修改入院登记出错!!!");
            XmlHelp.DeSerializerModel(new IniDto(), true);
        }
        /// <summary>
        /// 异地出院办理
        /// </summary>
        /// <param name="param"></param>
        public LeaveHospitalHandleDto LeaveHospitalHandle(YdInputLeaveHospitalHandleXml param)
        {
            var resultData = new LeaveHospitalHandleDto();
            var xmlStr = XmlHelp.SaveXml(param);
            if (!xmlStr) throw new Exception("异地出院办理保存参数出错");
            int result = MedicalInsuranceDll.CallService_cxjb("YYJK006");
            if (result != 1) throw new Exception("异地出院办理医保执行出错!!!");
            var data = XmlHelp.DeSerializerModel(new LeaveHospitalHandleJsonDto(), true);
            if (data!=null) resultData.OperationTime = data.OperationTime;
            return resultData;
        }
    }
}
