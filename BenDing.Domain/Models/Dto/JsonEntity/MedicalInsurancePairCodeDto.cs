using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDing.Domain.Models.Dto.JsonEntity
{
  public  class MedicalInsurancePairCodeDto
    {
        public string DirectoryCode { get; set; }
        public string ProjectCode { get; set; }
        public int DirectoryCategoryCode { get; set; }
    }
}
