using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDing.Domain.Models.DifferentPlacesXml.YdPrescriptionUpload;
using BenDing.Domain.Models.Dto.Resident;

namespace BenDing.Domain.Models.Params.DifferentPlaces
{
   public class GetYdPrescriptionUploadParam
    {
        public List<YdInputPrescriptionUploadXml> UploadList { get; set; }

        public RetrunPrescriptionUploadDto RetrunUpload { get; set; }
    }
}
