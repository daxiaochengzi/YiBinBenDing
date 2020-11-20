using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{/// <summary>
 /// 异地入院登记
 /// </summary>
    public  class YdHospitalizationRegisterUiParam : UiBaseDataParam
    {
        ///<summary>
        /// 个人编号
        /// </summary>
      
        [Display(Name = "个人编号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string PersonalNumber { get; set; }
        /// <summary>
        ///身份证号
        /// </summary>
       
        [Display(Name = "身份证号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdCardNo { get; set; }
        /// <summary>
        ///社保卡号（异地就医时会校验）
        /// </summary>
      
        [Display(Name = "社保卡号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string InsuranceNo { get; set; }
        /// <summary>
        /// 医疗类别  1医疗,2工伤医疗,3工伤康复
        /// </summary>
     
        [Display(Name = " 医疗类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string MedicalCategory { get; set; }
        /// <summary>
        /// 参保地统筹编码
        /// </summary>

        [Display(Name = "参保地统筹编码")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string AreaCode { get; set; }
        /// <summary>
        /// 结算json
        /// </summary>
        public string SettlementJson { get; set; }
        /// <summary>
        /// 入参xml
        /// </summary>
        public string InputXml { get; set; }
        /// <summary>
        /// 诊断
        /// </summary>

        public List<InpatientDiagnosisDto> DiagnosisList { get; set; } = null;
    }
}
