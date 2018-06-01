using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Geology;

namespace iS3.Server.DTO.Geology
{
    public class StratumSectionDTO : DGObjectDTO
    {
        public double? StartMileage { get; set; }
        public double? EndMileage { get; set; }
    }

    public class SoilDynamicPropertyDTO
    {
        public double? G0 { get; set; }
        public double? ar { get; set; }
        public double? br { get; set; }
    }

    public class SoilStaticPropertyDTO
    {
        public double? w { get; set; }
        public double? gama { get; set; }
        public double? c { get; set; }
        public double? fai { get; set; }
        public double? cuu { get; set; }
        public double? faiuu { get; set; }
        public double? Cs { get; set; }
        public double? qu { get; set; }
        public double? K0 { get; set; }
        public double? Kv { get; set; }
        public double? Kh { get; set; }
        public double? e { get; set; }
        public double? av { get; set; }
        public double? Cu { get; set; }

        public double? G { get; set; }
        public double? Sr { get; set; }
        public double? ccq { get; set; }
        public double? faicq { get; set; }
        public double? c_s { get; set; }
        public double? fais { get; set; }
        public double? a01_02 { get; set; }
        public double? Es01_02 { get; set; }
        public double? c_u { get; set; }
        public double? faiu { get; set; }
        public double? ccu { get; set; }
        public double? faicu { get; set; }
        public double? cprime { get; set; }
        public double? faiprime { get; set; }
        public double? E015_0025 { get; set; }
        public double? E02_0025 { get; set; }
        public double? E04_0025 { get; set; }
    }
    
    public class SoilPropertyDTO : DGObjectDTO
    {
        public int StratumID { get; set; }
        public int? StratumSectionID { get; set; }
        public SoilStaticPropertyDTO StaticProp { get; set; }
        public SoilDynamicPropertyDTO DynamicProp { get; set; }
    }
}