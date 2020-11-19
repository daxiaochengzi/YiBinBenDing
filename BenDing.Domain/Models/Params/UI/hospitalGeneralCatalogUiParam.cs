using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
  public  class HospitalGeneralCatalogUiParam: PaginationWebParam
    {
        /// <summary>
        /// 上传状态
        /// </summary>
        public int? UploadMark { get; set; }
    }
}
