using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI.DifferentPlaces
{
  public  class DoctorAdviceUploadUiParam:UiBaseDataParam
  {
      public int? DoctorAdviceUploadMark { get; set; } = null;

        public UserInfoDto User { get; set; }
    }
}
