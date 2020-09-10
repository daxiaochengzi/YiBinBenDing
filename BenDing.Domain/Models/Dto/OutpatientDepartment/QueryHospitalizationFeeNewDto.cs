using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class QueryHospitalizationFeeNewDto
    {/// <summary>
    /// 合计金额
    /// </summary>
        public decimal AllAmount { get; set; }
        /// <summary>
        /// 上传合计金额
        /// </summary>
        public decimal UploadAllAmount { get; set; }
        /// <summary>
        /// 未上传合计金额
        /// </summary>
        public decimal UnUploadAllAmount { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public  int Count { get; set; }
        /// <summary>
        /// 查询数据
        /// </summary>

        public List<QueryHospitalizationFeeDto> QueryData { get; set; }

    }
}
