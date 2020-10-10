using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Enums;

namespace BenDing.Domain.Models.Dto.SystemManage
{
    public class HospitalOrganizationGradeDto
    {
        /// <summary>
        /// 行政区域
        /// </summary>
        public string AdministrativeArea { get; set; }

        /// <summary>
        /// 医院等级
        /// </summary>
        public OrganizationGrade OrganizationGrade { get; set; }

        /// <summary>
        /// 医保账户
        /// </summary>
        public string MedicalInsuranceAccount { get; set; }

        /// <summary>
        /// 医保密码
        /// </summary>
        public string MedicalInsurancePwd { get; set; }

        /// <summary>
        /// 医保固定编码
        /// </summary>
        public string MedicalInsuranceHandleNo { get; set; }

        /// <summary>
        /// 有效时间
        /// </summary>
        public string EffectiveTime { get; set; }

        /// <summary>
        /// 门诊
        /// </summary>
        public bool? Outpatient { get; set; }

        /// <summary>
        /// 住院
        /// </summary>
        public bool? Hospital { get; set; }

        /// <summary>
        /// 生育
        /// </summary>
        public bool? BirthHospital { get; set; }

        /// <summary>
        /// 异地
        /// </summary>
        public bool? AnotherPlace { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 是否暂停
        /// </summary>
        public  int IsSuspend { get; set; }
    }
}
