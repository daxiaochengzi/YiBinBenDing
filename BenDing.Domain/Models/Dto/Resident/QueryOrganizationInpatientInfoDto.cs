using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Resident
{
   public class QueryOrganizationInpatientInfoDto
    {/// <summary>
    /// 业务id
    /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public  string IdCardNo { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public  string HospitalizationNo { get; set; }
        /// <summary>
        /// 入院登记时间
        /// </summary>
        public  DateTime AdmissionDate { get; set; }
        /// <summary>
        /// 合计条数
        /// </summary>
        public  int AllNum { get; set; }
        /// <summary>
        /// 上传条数
        /// </summary>
        public int UploadNum { get; set; }
        /// <summary>
        /// 未上传条数
        /// </summary>
        public int NotUploadNum { get; set; }

    }
}
