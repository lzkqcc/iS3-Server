using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Geology;

namespace iS3.Server.DTO.Geology
{
    public class BoreholeGeologyDTO
    {
        public double Top { get; set; }
        public double Base { get; set; }
        public int StratumID { get; set; }
    }
    
    public class BoreholeDTO : DGObjectDTO
    {
        public double Top { get; set; }
        public double Base { get; set; }
        public double? Mileage { get; set; }
        public string Type { get; set; }
        public List<BoreholeGeologyDTO> geologies { get; set; }
    }
}