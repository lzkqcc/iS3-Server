using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Geology;

namespace iS3.Server.DTO.Geology
{
    public class StratumDTO : DGObjectDTO
    {
        public string GeologyAge { get; set; }
        public string FormationType { get; set; }
        public string Compaction { get; set; }
        public string ElevationRange { get; set; }
        public string ThicknessRange { get; set; }
    }
}