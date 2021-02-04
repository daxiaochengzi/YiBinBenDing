using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.OutpatientDepartment
{
   public class OutpatientPairCodeQueryDto
    {  /// <summary>
    /// 项目编码
    /// </summary>
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string DirectoryName { get; set; }
        /// <summary>
        /// 对码状态
        /// </summary>
        public int PairCodeState { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public  string Specification { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string ManufacturerName { get; set; }
      
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 不传标记
        /// </summary>
        public int? NotUploadMark { get; set; }
       /// <summary>
       /// 业务id
       /// </summary>
        public  string DetailId { get; set; }
    }
}
