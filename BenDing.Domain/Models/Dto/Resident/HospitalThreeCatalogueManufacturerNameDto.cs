using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.Resident
{
  public  class HospitalThreeCatalogueManufacturerNameDto
    { /// <summary>
    /// 目录编码
    /// </summary>
        public string DirectoryCode { get; set;  }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string ManufacturerName { get; set; }
    }
}
