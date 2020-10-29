﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.JsonEntity;
using BenDing.Domain.Models.Dto.OutpatientDepartment;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Dto.Workers;
using BenDing.Domain.Models.Enums;
using BenDing.Domain.Models.HisXml;
using BenDing.Domain.Models.Params.Base;
using BenDing.Domain.Models.Params.OutpatientDepartment;
using BenDing.Domain.Models.Params.Resident;
using BenDing.Domain.Models.Params.SystemManage;
using BenDing.Domain.Models.Params.UI;
using BenDing.Domain.Models.Params.Web;
using BenDing.Domain.Xml;
using BenDing.Repository.Interfaces.Web;
using BenDing.Service.Interfaces;
using Newtonsoft.Json;
using NFine.Application.BenDingManage;
using NFine.Domain._03_Entity.BenDingManage;

namespace BenDing.Service.Providers
{
    public class OutpatientDepartmentNewService : IOutpatientDepartmentNewService
    {
        private readonly IOutpatientDepartmentRepository _outpatientDepartmentRepository;
        private readonly IWebServiceBasicService _serviceBasicService;
        private readonly IWebBasicRepository _webBasicRepository;
        private readonly IHisSqlRepository _hisSqlRepository;
        private readonly ISystemManageRepository _systemManageRepository;
        private readonly IResidentMedicalInsuranceRepository _residentMedicalInsuranceRepository;
        private readonly IResidentMedicalInsuranceService _residentMedicalInsuranceService;
        private readonly IMedicalInsuranceSqlRepository _medicalInsuranceSqlRepository;
        private readonly MonthlyHospitalizationBase _monthlyHospitalizationBase;
        public OutpatientDepartmentNewService(
            IOutpatientDepartmentRepository outpatientDepartmentRepository,
            IWebServiceBasicService webServiceBasicService,
            IWebBasicRepository webBasicRepository,
            IHisSqlRepository hisSqlRepository,
            ISystemManageRepository systemManageRepository,
            IResidentMedicalInsuranceRepository residentMedicalInsuranceRepository,
            IMedicalInsuranceSqlRepository medicalInsuranceSqlRepository,
            IResidentMedicalInsuranceService medicalInsuranceService
        )
        {
            _serviceBasicService = webServiceBasicService;
            _outpatientDepartmentRepository = outpatientDepartmentRepository;
            _webBasicRepository = webBasicRepository;
            _hisSqlRepository = hisSqlRepository;
            _systemManageRepository = systemManageRepository;
            _residentMedicalInsuranceRepository = residentMedicalInsuranceRepository;
            _medicalInsuranceSqlRepository = medicalInsuranceSqlRepository;
            _residentMedicalInsuranceService = medicalInsuranceService;
            _monthlyHospitalizationBase = new MonthlyHospitalizationBase();
        }
        /// <summary>
        /// 获取普通门诊结算入参
        /// </summary>
        /// <returns></returns>
        public OutpatientDepartmentCostInputParam GetOutpatientDepartmentCostInputParam(GetOutpatientPersonParam param)
        { 
          
            //获取门诊病人数据
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(param);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
           
            var inputParam = new OutpatientDepartmentCostInputParam()
            {
                AllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                IdentityMark = param.IdentityMark,
                AfferentSign = param.AfferentSign,
                Operators = param.User.UserName
            };
          

            return inputParam;
        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public OutpatientDepartmentCostInputDto OutpatientDepartmentCostInput(GetOutpatientPersonParam param)
        {
            OutpatientDepartmentCostInputDto resultData = null;
            var iniData = JsonConvert.DeserializeObject<OutpatientDepartmentCostInputJsonDto>(param.SettlementXml);
            resultData = AutoMapper.Mapper.Map<OutpatientDepartmentCostInputDto>(iniData);
            //获取门诊病人数据
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(param);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");

            var inputParam = new OutpatientDepartmentCostInputParam()
            {
                AllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                IdentityMark = param.IdentityMark,
                AfferentSign = param.AfferentSign,
                Operators = param.User.UserName
            };
            param.IsSave = true;
            param.Id = Guid.NewGuid();
            //保存门诊病人
            _serviceBasicService.GetOutpatientPerson(param);
            //中间层数据写入
            var saveData = new MedicalInsuranceDto
            {
                AdmissionInfoJson = JsonConvert.SerializeObject(param),
                BusinessId = param.UiParam.BusinessId,
                Id = Guid.NewGuid(),
                IsModify = false,
                InsuranceType = 999,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceHospitalized,
                MedicalInsuranceHospitalizationNo = resultData.DocumentNo,
                AfferentSign = param.AfferentSign,
                IdentityMark = param.IdentityMark
            };
            //存中间库
            _medicalInsuranceSqlRepository.SaveMedicalInsurance(param.User, saveData);

            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = param.User,
                JoinOrOldJson = JsonConvert.SerializeObject(inputParam),
                ReturnOrNewJson = JsonConvert.SerializeObject(resultData),
                RelationId = param.Id,
                BusinessId = param.UiParam.BusinessId,
                
                Remark = "[R][OutpatientDepartment]门诊病人结算",
                
            });
        
            //回参构建
            var xmlData = new OutpatientDepartmentCostXml()
            {
                AccountBalance = !string.IsNullOrWhiteSpace(param.AccountBalance) == true ? Convert.ToDecimal(param.AccountBalance) : 0,
                MedicalInsuranceOutpatientNo = resultData.DocumentNo,
                CashPayment = resultData.SelfPayFeeAmount,
                SettlementNo = resultData.DocumentNo,
                AllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                PatientName = outpatientPerson.PatientName,
                AccountAmountPay = 0,
                MedicalInsuranceType = param.InsuranceType == "310" ? "1" : param.InsuranceType,
            };

            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = param.User,
                MedicalInsuranceBackNum = "zydj",
                MedicalInsuranceCode = "48",
                BusinessId = param.UiParam.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);
            var updateParam = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.User.UserId,
                ReimbursementExpensesAmount = resultData.ReimbursementExpensesAmount,
                SelfPayFeeAmount = resultData.SelfPayFeeAmount,
                OtherInfo = JsonConvert.SerializeObject(resultData),
                Id = saveData.Id,
                SettlementNo = resultData.DocumentNo,
                MedicalInsuranceAllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                SettlementTransactionId = param.User.TransKey,
                MedicalInsuranceState = MedicalInsuranceState.HisSettlement
            };
            //更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParam);
            return resultData;
        }
        /// <summary>
        /// 获取取消结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetCancelOutpatientDepartmentCostParam(CancelOutpatientDepartmentCostUiParam param)
        {
            string resultData = null;
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //获取医保病人信息
            var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
                OrganizationCode = userBase.OrganizationCode
            };
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);
            if (residentData == null) throw new Exception("当前病人未结算,不能取消结算!!!");
            if (residentData.MedicalInsuranceState != MedicalInsuranceState.HisSettlement) throw new Exception("当前病人未结算,不能取消结算!!!");
            //划卡
            if (residentData.SettlementType == "2")
            {
                var inputParam = new WorkerCancelSettlementCardParam()
                {
                    SettlementNo = residentData.SettlementNo,
                    CancelRemarks = param.CancelSettlementRemarks,
                    OperatorName= userBase.UserName
                };
                resultData = XmlSerializeHelper.XmlSerialize(inputParam);
            }

           if (residentData.SettlementType == null)
            {//生育
                if (residentData.IsBirthHospital == 1)
                {
                    var inputParam = new OutpatientPlanBirthSettlementCancelParam()
                    {
                        SettlementNo = residentData.SettlementNo,
                        CancelRemarks = param.CancelSettlementRemarks
                    };
                    resultData = XmlSerializeHelper.XmlSerialize(inputParam);
                }
                else
                {
                    var inputParam = new CancelOutpatientDepartmentCostParam()
                    {
                        DocumentNo = residentData.SettlementNo
                    };
                    resultData = XmlSerializeHelper.XmlSerialize(inputParam);
                }
            }


            return resultData;
        }
        /// <summary>
        /// 门诊取消结算
        /// </summary>
        /// <param name="param"></param>
        public void CancelOutpatientDepartmentCost(CancelOutpatientDepartmentCostUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //获取医保病人信息
            var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
                OrganizationCode = userBase.OrganizationCode
            };
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);
            if (residentData == null) throw new Exception("当前病人未结算,不能取消结算!!!");
            if (residentData.MedicalInsuranceState != MedicalInsuranceState.HisSettlement) throw new Exception("当前病人未结算,不能取消结算!!!");
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = userBase,
                Remark = "门诊取消结算",
                RelationId = residentData.Id,
                BusinessId = param.BusinessId,
            };
            _systemManageRepository.AddHospitalLog(logParam);

            //回参构建
            var xmlData = new OutpatientDepartmentCostCancelXml()
            {
                SettlementNo = residentData.SettlementNo
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "Qxjs",
                MedicalInsuranceCode = "42MZ",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
            _webBasicRepository.SaveXmlData(saveXml);

            var updateParamData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.UserId,
                Id = residentData.Id,
                CancelTransactionId = param.TransKey,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceCancelSettlement,
                IsHisUpdateState = true,
                CancelSettlementRemarks = param.CancelSettlementRemarks
            };
            //更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParamData);

        }
        /// <summary>
        /// 获取门诊计划生育预结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <returns></returns>
        public OutpatientPlanBirthPreSettlementParam GetOutpatientPlanBirthPreSettlementParam(
            OutpatientPlanBirthPreSettlementUiParam param
        )
        {
           
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            var outpatientDetailPerson = _serviceBasicService.GetOutpatientDetailPerson(new OutpatientDetailParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            });
            //获取主诊断
            var diagnosisData = outpatientPerson.DiagnosisList.FirstOrDefault(c => c.IsMainDiagnosis == "是");
            var inpatientDiagnosisDataDto = diagnosisData;
            if (inpatientDiagnosisDataDto == null) throw new Exception("计划生育主诊断不能为空");
            if (!string.IsNullOrWhiteSpace(inpatientDiagnosisDataDto.ProjectCode)==false)throw new Exception("诊断:"+inpatientDiagnosisDataDto.DiseaseName+"未医保对码!!!");
            List<string> diagnosisCode;
            diagnosisCode = new List<string>();
            diagnosisCode.Add("O04.905"); diagnosisCode.Add("O04.902");
            diagnosisCode.Add("O04.901");
            var diagnosisResult = diagnosisCode.Where(c => c.Contains(inpatientDiagnosisDataDto.ProjectCode));
            if (diagnosisResult==null) throw new Exception("诊断:" + inpatientDiagnosisDataDto.DiseaseName + "不属于计划生育诊断!!!");

            var resultData = new OutpatientPlanBirthPreSettlementParam()
            {
                OutpatientNo = CommonHelp.GuidToStr(param.BusinessId),//outpatientPerson.OutpatientNumber,
                DiagnosisDate = Convert.ToDateTime(outpatientPerson.VisitDate).ToString("yyyyMMddHHmmss"),
                ProjectNum = outpatientDetailPerson.Count(),
                TotalAmount = outpatientPerson.MedicalTreatmentTotalCost,
                AfferentSign = param.AfferentSign,
                IdentityMark = param.IdentityMark,
                AdmissionMainDiagnosisIcd10 =  diagnosisData.ProjectCode

            };
            var rowDataList = new List<PlanBirthSettlementRow>();
            //升序
            var dataSort = outpatientDetailPerson.OrderBy(c => c.BillTime).ToArray();
            int num = 0;
            foreach (var item in dataSort)
            {
                if (string.IsNullOrWhiteSpace(item.MedicalInsuranceProjectCode)) throw new Exception("[" + item + "]名称:" + item.DirectoryName + "未对码!!!");
                if (!string.IsNullOrWhiteSpace(item.MedicalInsuranceProjectCode))
                {
                    var row = new PlanBirthSettlementRow()
                    {
                        ColNum = num,
                        ProjectCode = item.MedicalInsuranceProjectCode,
                        ProjectName = item.DirectoryName,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        TotalAmount =CommonHelp.ValueToDouble(item.Amount),
                        Formulation = item.Formulation,
                        ManufacturerName = item.DrugProducingArea,
                        Dosage = item.Dosage,
                        Specification = item.Specification,
                        Usage = item.Usage
                    };

                    rowDataList.Add(row);
                    num++;
                }


            }

            resultData.RowDataList = rowDataList;

          
            return resultData;

        }
        /// <summary>
        /// 获取门诊计划生育结算参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <returns></returns>
        public OutpatientPlanBirthSettlementParam GetOutpatientPlanBirthSettlementParam(
           OutpatientPlanBirthSettlementUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            var outpatientDetailPerson = _serviceBasicService.GetOutpatientDetailPerson(new OutpatientDetailParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            });
            //获取主诊断
            var diagnosisData = outpatientPerson.DiagnosisList.FirstOrDefault(c => c.IsMainDiagnosis == "是");
           
            var inpatientDiagnosisDataDto = diagnosisData;
            if (inpatientDiagnosisDataDto == null) throw new Exception("计划生育主诊断不能为空");
            if (!string.IsNullOrWhiteSpace(inpatientDiagnosisDataDto.ProjectCode) == false) throw new Exception("诊断:" + inpatientDiagnosisDataDto.DiseaseName + "未医保对码!!!");
            List<string> diagnosisCode;
            diagnosisCode = new List<string>();
            diagnosisCode.Add("O04.905"); diagnosisCode.Add("O04.902");
            diagnosisCode.Add("O04.901");
            var diagnosisResult = diagnosisCode.Where(c => c.Contains(inpatientDiagnosisDataDto.ProjectCode));
            if (diagnosisResult == null) throw new Exception("诊断:" + inpatientDiagnosisDataDto.DiseaseName + "不属于计划生育诊断!!!");
            var resultData = new OutpatientPlanBirthSettlementParam()
            {
                OutpatientNo = CommonHelp.GuidToStr(param.BusinessId),
                DiagnosisDate = Convert.ToDateTime(outpatientPerson.VisitDate).ToString("yyyyMMddHHmmss"),
                ProjectNum = outpatientDetailPerson.Count(),
                TotalAmount = outpatientPerson.MedicalTreatmentTotalCost,
                AfferentSign = param.AfferentSign,
                AccountPayment = string.IsNullOrWhiteSpace(param.AccountPayment) == true ? 0 : Convert.ToDecimal(param.AccountPayment),
                IdentityMark = param.IdentityMark,
                AdmissionMainDiagnosisIcd10 = diagnosisData.ProjectCode

            };
            var rowDataList = new List<PlanBirthSettlementRow>();
            //升序
            var dataSort = outpatientDetailPerson.OrderBy(c => c.BillTime).ToArray();
            int num = 0;
            foreach (var item in dataSort)
            {
                if (string.IsNullOrWhiteSpace(item.MedicalInsuranceProjectCode)) throw new Exception("[" + item + "]名称:" + item.DirectoryName + "未对码!!!");
                if (!string.IsNullOrWhiteSpace(item.MedicalInsuranceProjectCode))
                {
                    var row = new PlanBirthSettlementRow()
                    {
                        ColNum = num,
                        ProjectCode = item.MedicalInsuranceProjectCode,
                        ProjectName = item.DirectoryName,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        TotalAmount = item.Amount,
                        Formulation = item.Formulation,
                        ManufacturerName = item.DrugProducingArea,
                        Dosage = item.Dosage,
                        Specification = item.Specification,
                        Usage = item.Usage
                    };

                    rowDataList.Add(row);
                    num++;
                }


            }

            resultData.RowDataList = rowDataList;

            //var dataXmlStr = XmlSerializeHelper.XmlSerialize(resultData);
            //return dataXmlStr;

            return resultData;
        }
        /// <summary>
        /// 门诊计划生育预结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public WorkerBirthSettlementDto OutpatientPlanBirthPreSettlement(
            OutpatientPlanBirthPreSettlementUiParam param)
        {
            WorkerBirthSettlementDto resultData;
            var iniData = JsonConvert.DeserializeObject<WorkerBirthPreSettlementJsonDto>(param.SettlementJson);
            resultData = AutoMapper.Mapper.Map<WorkerBirthSettlementDto>(iniData);
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
           
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
         
            
            //保存门诊病人
            outpatientParam.IsSave = true;
            outpatientParam.Id = Guid.NewGuid();
            _serviceBasicService.GetOutpatientPerson(outpatientParam);
            var saveData = new MedicalInsuranceDto
            {
                AdmissionInfoJson = JsonConvert.SerializeObject(param),
                BusinessId = param.BusinessId,
                Id = Guid.NewGuid(),
                IsModify = false,
                InsuranceType = 999,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsurancePreSettlement,
                AfferentSign = param.AfferentSign,
                IdentityMark = param.IdentityMark,
                IsBirthHospital = 1
            };
            //存中间库
            _medicalInsuranceSqlRepository.SaveMedicalInsurance(userBase, saveData);
            //初始化入参
            var iniParam = GetOutpatientPlanBirthPreSettlementParam(param);
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                JoinOrOldJson = JsonConvert.SerializeObject(iniParam),
                ReturnOrNewJson = JsonConvert.SerializeObject(resultData),
                RelationId = outpatientParam.Id,
                BusinessId = param.BusinessId,
                Remark = "[R][OutpatientDepartment]门诊计划生育预结算"
            });
            //明细存入
            _serviceBasicService.GetOutpatientDetailPerson(new OutpatientDetailParam()
            {
                IsSave = true,
                BusinessId = param.BusinessId,
                User = userBase
            });
           
            return resultData;
        }
        /// <summary>
        /// 门诊计划生育结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public WorkerBirthSettlementDto OutpatientPlanBirthSettlement(
          OutpatientPlanBirthSettlementUiParam param)
        {
            WorkerBirthSettlementDto resultData;

            var iniData = JsonConvert.DeserializeObject<WorkerBirthPreSettlementJsonDto>(param.SettlementJson);
            resultData = AutoMapper.Mapper.Map<WorkerBirthSettlementDto>(iniData);
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //门诊病人信息存储
            var id = Guid.NewGuid();
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
                Id = id,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            //var outpatientDetailPerson = _serviceBasicService.GetOutpatientDetailPerson(new OutpatientDetailParam()
            //{
            //    User = userBase,
            //    BusinessId = param.BusinessId,
            //});
            var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
            };
            //获取医保病人信息
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);
            if (residentData.MedicalInsuranceState != MedicalInsuranceState.MedicalInsurancePreSettlement) throw new Exception("当前病人未办理预结算,不能办理结算!!!");
            if (residentData.MedicalInsuranceState == MedicalInsuranceState.HisSettlement) throw new Exception("当前病人已办理医保结算,不能办理再次结算!!!");
            
            //_serviceBasicService.GetOutpatientPerson(outpatientParam);
            var accountPayment = resultData.AccountPayment + resultData.CivilServantsSubsidies +
                                 resultData.CivilServantsSubsidy + resultData.OtherPaymentAmount +
                                 resultData.BirthAllowance + resultData.SupplementPayAmount;
            var cashPayment = CommonHelp.ValueToDouble((outpatientPerson.MedicalTreatmentTotalCost - accountPayment));
              var updateData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = userBase.UserId,
                ReimbursementExpensesAmount = CommonHelp.ValueToDouble(accountPayment),
                SelfPayFeeAmount = resultData.CashPayment,
                OtherInfo = JsonConvert.SerializeObject(resultData),
                Id = residentData.Id,
                SettlementNo = resultData.DocumentNo,
                MedicalInsuranceAllAmount = resultData.TotalAmount,
                SettlementTransactionId = userBase.UserId,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceSettlement
            };
            //存入中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateData);
            var iniParam = GetOutpatientPlanBirthSettlementParam(param);
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                JoinOrOldJson = JsonConvert.SerializeObject(iniParam),
                ReturnOrNewJson = JsonConvert.SerializeObject(resultData),
                RelationId = outpatientParam.Id,
                BusinessId = param.BusinessId,
                Remark = "[R][OutpatientDepartment]门诊生育结算"
            });
         
           
            // 回参构建
            var xmlData = new OutpatientDepartmentCostXml()
            {
                AccountBalance = !string.IsNullOrWhiteSpace(param.AccountBalance) == true ? Convert.ToDecimal(param.AccountBalance) : 0,
                MedicalInsuranceOutpatientNo = resultData.DocumentNo,
                CashPayment =cashPayment < 0 ? 0 : cashPayment,
                SettlementNo = resultData.DocumentNo,
                AllAmount = CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost),
                PatientName = outpatientPerson.PatientName,
                AccountAmountPay = resultData.AccountPayment,
                MedicalInsuranceType = param.InsuranceType == "310" ? "1" : param.InsuranceType,
            };

            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "zydj",
                MedicalInsuranceCode = "48",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            ////存基层
            _webBasicRepository.SaveXmlData(saveXml);
            var updateParamData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.UserId,
                Id = residentData.Id,
                MedicalInsuranceState = MedicalInsuranceState.HisSettlement,
                IsHisUpdateState = true
            };
            //  更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParamData);

            return resultData;
        }
        /// <summary>
        /// 获取门诊电子卡参数
        /// </summary>
        public NationEcTransParam OutpatientNationEcTransParam(OutpatientNationEcTransUiParam param)
        {
            var resultData = new NationEcTransParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;

            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
                IsSave = true,
                Id = Guid.NewGuid(),
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            var outpatientDetailPerson = _serviceBasicService.GetOutpatientDetailPerson(new OutpatientDetailParam()
            {
                User = userBase,
                BusinessId = param.BusinessId,
            });
            var saveData = new MedicalInsuranceDto
            {
                AdmissionInfoJson = JsonConvert.SerializeObject(param),
                BusinessId = param.BusinessId,
                Id = Guid.NewGuid(),
                IsModify = false,
                InsuranceType =Convert.ToInt16(param.InsuranceType) ,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsurancePreSettlement,
                AfferentSign = param.AfferentSign,
                IdentityMark = param.IdentityMark,
              
            };
            _medicalInsuranceSqlRepository.SaveMedicalInsurance(userBase, saveData);
            var rowDataList = new List<NationEcTransRow>();
          
            resultData.DownAccountType = "1";
            //resultData.Remark = param.Remark;
            //decimal downAccountAmount = 0;
            //if (!string.IsNullOrWhiteSpace(param.DownAccountAmount))
            //{
            //    downAccountAmount = Convert.ToDecimal(param.DownAccountAmount);
            //}
            resultData.DownAccountAmount =CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost);
            //升序
            var dataSort = outpatientDetailPerson.OrderBy(c => c.BillTime).ToArray();
            int num = 0;
            foreach (var item in dataSort)
            {
                if (string.IsNullOrWhiteSpace(item.MedicalInsuranceProjectCode)) throw new Exception("[" + item + "]名称:" + item.DirectoryName + "未对码!!!");
                if (!string.IsNullOrWhiteSpace(item.MedicalInsuranceProjectCode))
                {
                    var row = new NationEcTransRow()
                    {
                        ColNum = num.ToString(),
                        ProjectCode = item.MedicalInsuranceProjectCode,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        TotalAmount =CommonHelp.ValueToDouble(item.Amount) ,
                        DirectoryName = item.DirectoryName,
                        DirectoryCode =CommonHelp.GuidToStr(item.DirectoryCode),

                    };

                    rowDataList.Add(row);
                    num++;
                }


            }
            resultData.Nums = rowDataList.Count();
            resultData.RowDataList = rowDataList;
            return resultData;
        }

        /// <summary>
        /// 门诊电子医保
        /// </summary>
        /// <param name="param"></param>
        public void OutpatientNationEcTrans(OutpatientNationEcTransUiParam param)
        {
            var iniData = JsonConvert.DeserializeObject<NationEcTransDto>(param.SettlementJson);
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //门诊病人信息存储
            var id = Guid.NewGuid();
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
                Id = id,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
            };
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                ReturnOrNewJson = JsonConvert.SerializeObject(iniData),
                RelationId = outpatientParam.Id,
                BusinessId = param.BusinessId,
                Remark = iniData.SerialNumber+"电子记录好"
            });
            //获取医保病人信息
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);
            if (residentData.MedicalInsuranceState != MedicalInsuranceState.MedicalInsurancePreSettlement) throw new Exception("当前病人未办理预结算,不能办理结算!!!");
            //存中间库

            var updateData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = userBase.UserId,
                SelfPayFeeAmount = iniData.SelfPayAmount,
                OtherInfo = JsonConvert.SerializeObject(iniData),
                Id = residentData.Id,
                SettlementNo = iniData.AccountPaySerialNumber,
                MedicalInsuranceAllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                SettlementTransactionId = userBase.UserId,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceSettlement
            };
            //存入中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateData);

            // 回参构建
            var xmlData = new OutpatientDepartmentCostXml()
            {
                AccountBalance = !string.IsNullOrWhiteSpace(param.AccountBalance) == true ? Convert.ToDecimal(param.AccountBalance) : 0,
                MedicalInsuranceOutpatientNo = iniData.AccountPaySerialNumber,
                CashPayment = iniData.SelfPayAmount < 0 ? 0 : iniData.SelfPayAmount,
                SettlementNo = iniData.AccountPaySerialNumber,
                AllAmount = CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost),
                PatientName = outpatientPerson.PatientName,
                AccountAmountPay = iniData.AccountPayAmount,
                MedicalInsuranceType = param.InsuranceType == "310" ? "1" : param.InsuranceType,
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "zydj",
                MedicalInsuranceCode = "48",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            ////存基层
          //  _webBasicRepository.SaveXmlData(saveXml);
            var updateParamData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.UserId,
                Id = residentData.Id,
                MedicalInsuranceState = MedicalInsuranceState.HisSettlement,
                IsHisUpdateState = true
            };
            //  更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParamData);
        }

        /// <summary>
        /// 获取划卡参数
        /// </summary>
        public WorkerHospitalSettlementCardParam WorkerOutpatientSettlementCardParam(WorkerHospitalSettlementCardUiParam param)
        {
            var resultData = new WorkerHospitalSettlementCardParam();
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
                IsSave = true,
                Id = Guid.NewGuid(),
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            var hospitalData = _systemManageRepository.QueryHospitalOrganizationGrade(userBase.OrganizationCode);

            resultData.OperatorName = outpatientPerson.Operator;
            resultData.TotalAmount = CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost).ToString(CultureInfo.InvariantCulture);
            resultData.UseCardType = "1";
            resultData.CardPwd = "";
            resultData.HospitalLogNo = hospitalData.MedicalInsuranceHandleNo;
              var saveData = new MedicalInsuranceDto
            {
                AdmissionInfoJson = JsonConvert.SerializeObject(param),
                BusinessId = param.BusinessId,
                Id = Guid.NewGuid(),
                IsModify = false,
                InsuranceType = Convert.ToInt16(param.InsuranceType),
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsurancePreSettlement,
                AfferentSign = param.AfferentSign,
                IdentityMark = param.IdentityMark,
            };
            _medicalInsuranceSqlRepository.SaveMedicalInsurance(userBase, saveData);
            
            
            return resultData;
        }
        /// <summary>
        /// 门诊划卡
        /// </summary>
        /// <param name="param"></param>
        public WorkerHospitalSettlementCardBackDto WorkerOutpatientSettlementCard(WorkerHospitalSettlementCardUiParam param)
        {
            var iniData = JsonConvert.DeserializeObject<WorkerHospitalSettlementCardBackDataDto>(param.SettlementJson);
            var resultData= AutoMapper.Mapper.Map<WorkerHospitalSettlementCardBackDto>(iniData);
            //var iniData = new WorkerHospitalSettlementCardBackDto()
            //{
            //    AccountPayment =Convert.ToDecimal(10.92),
            //    AccountBalance = 500,
            //    SerialNumber = "12312dqeqwe"
            //};
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            userBase.TransKey = param.TransKey;
            //门诊病人信息存储
            var id = Guid.NewGuid();
            var outpatientParam = new GetOutpatientPersonParam()
            {
                User = userBase,
                UiParam = param,
                Id = id,
            };
            var outpatientPerson = _serviceBasicService.GetOutpatientPerson(outpatientParam);
            if (outpatientPerson == null) throw new Exception("his中未获取到当前病人!!!");
            var queryResidentParam = new QueryMedicalInsuranceResidentInfoParam()
            {
                BusinessId = param.BusinessId,
            };
            //日志写入
            _systemManageRepository.AddHospitalLog(new AddHospitalLogParam()
            {
                User = userBase,
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                ReturnOrNewJson = JsonConvert.SerializeObject(iniData),
                RelationId = outpatientParam.Id,
                BusinessId = param.BusinessId,
                Remark = iniData.SerialNumber + "电子记录好"
            });
            //获取医保病人信息
            var residentData = _medicalInsuranceSqlRepository.QueryMedicalInsuranceResidentInfo(queryResidentParam);
            if (residentData.MedicalInsuranceState != MedicalInsuranceState.MedicalInsurancePreSettlement) throw new Exception("当前病人未办理预结算,不能办理结算!!!");
            //存中间库

            var updateData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = userBase.UserId,
                SelfPayFeeAmount = iniData.CashPayment,
                OtherInfo = JsonConvert.SerializeObject(resultData),
                Id = residentData.Id,
                SettlementNo = iniData.SerialNumber,
                MedicalInsuranceAllAmount = outpatientPerson.MedicalTreatmentTotalCost,
                SettlementTransactionId = userBase.UserId,
                MedicalInsuranceState = MedicalInsuranceState.MedicalInsuranceSettlement,
                SettlementType = "2"
            };
            //存入中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateData);

            // 回参构建
            var xmlData = new OutpatientDepartmentCostXml()
            {
                AccountBalance = iniData.AccountBalance,
                MedicalInsuranceOutpatientNo = iniData.SerialNumber,
                CashPayment = iniData.CashPayment,
                SettlementNo = iniData.SerialNumber,
                AllAmount = CommonHelp.ValueToDouble(outpatientPerson.MedicalTreatmentTotalCost),
                PatientName = outpatientPerson.PatientName,
                AccountAmountPay = iniData.AccountPayment,
                MedicalInsuranceType = param.InsuranceType == "310" ? "1" : param.InsuranceType,
            };
            var strXmlBackParam = XmlSerializeHelper.HisXmlSerialize(xmlData);
            var saveXml = new SaveXmlDataParam()
            {
                User = userBase,
                MedicalInsuranceBackNum = "zydj",
                MedicalInsuranceCode = "48",
                BusinessId = param.BusinessId,
                BackParam = strXmlBackParam
            };
            //存基层
             _webBasicRepository.SaveXmlData(saveXml);
            var updateParamData = new UpdateMedicalInsuranceResidentSettlementParam()
            {
                UserId = param.UserId,
                Id = residentData.Id,
                MedicalInsuranceState = MedicalInsuranceState.HisSettlement,
                IsHisUpdateState = true
            };
            //  更新中间层
            _medicalInsuranceSqlRepository.UpdateMedicalInsuranceResidentSettlement(updateParamData);
            return resultData;
        }
        /// <summary>
        /// 获取门诊月结入参
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MonthlyHospitalizationParam GetMonthlyHospitalizationParam(MonthlyHospitalizationUiParam param)
        {
            //var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
           
            var iniParam = 
                new MonthlyHospitalizationParam()
                {
                    User = new UserInfoDto(),
                    Participation = new MonthlyHospitalizationParticipationParam()
                    {
                        StartTime = Convert.ToDateTime(param.StartTime).ToString("yyyyMMdd"),
                        EndTime = Convert.ToDateTime(param.EndTime).ToString("yyyyMMdd"),
                        SummaryType = "22",
                        PeopleType = ((int)param.PeopleType).ToString()
                    }
                };

            return iniParam;
        }

        public MonthlyHospitalizationCancelParam GetMonthlyHospitalizationCancelUiParam(GetMonthlyHospitalizationCancelUiParam param)
        {
            var resultData = new MonthlyHospitalizationCancelParam();
           var monthlyData= _monthlyHospitalizationBase.GetForm(Guid.Parse(param.Id));
            if (monthlyData.IsRevoke)throw  new Exception("本条记录已取消,不能再次操作");
            //var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            resultData.DocumentNo = monthlyData.DocumentNo;
            resultData.PeopleType = monthlyData.PeopleType;
            resultData.SummaryType = monthlyData.SummaryType;


            return resultData;
        }

        /// <summary>
        /// 门诊月结
        /// </summary>
        /// <param name="param"></param>
        public void MonthlyHospitalization(MonthlyHospitalizationUiParam param)
        {
            var userBase = _serviceBasicService.GetUserBaseInfo(param.UserId);
            MonthlyHospitalizationDto data;

            data = JsonConvert.DeserializeObject<MonthlyHospitalizationDto>(param.SettlementJson);
            var insertParam = new MonthlyHospitalizationEntity()
            {
                Amount = data.ReimbursementAllAmount,
                Id = Guid.NewGuid(),
                DocumentNo = data.DocumentNo,
                PeopleNum = data.ReimbursementPeopleNum,
                PeopleType = ((int)param.PeopleType).ToString(),
                SummaryType = "22",
                StartTime = Convert.ToDateTime(param.StartTime + " 00:00:00.000"),
                EndTime = Convert.ToDateTime(param.EndTime + " 00:00:00.000"),
                IsRevoke = false
            };
            _monthlyHospitalizationBase.Insert(insertParam, userBase);
            //添加日志
            var logParam = new AddHospitalLogParam()
            {
                JoinOrOldJson = JsonConvert.SerializeObject(param),
                User = userBase,
                Remark = "门诊月结汇总",
                RelationId = insertParam.Id,
               
            };
            _systemManageRepository.AddHospitalLog(logParam);
        }
    }
}

