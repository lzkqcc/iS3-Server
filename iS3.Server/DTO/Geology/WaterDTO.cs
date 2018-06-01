using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Geology;

namespace iS3.Server.DTO.Geology
{
    public class WaterDTO : DGObjectDTO
    {
        public WaterDTO() { }
    }

    public class RiverWaterDTO : WaterDTO
    {
        public string ObservationLocation { get; set; }
        public double? HighestTidalLevel { get; set; }
        public double? LowestTidalLevel { get; set; }
        public double? AvHighTidalLevel { get; set; }
        public double? AvLowTidalLevel { get; set; }
        public double? AvTidalRange { get; set; }
        public DateTime? HighestTidalLevelDate { get; set; }
        public DateTime? LowestTidalLevelDate { get; set; }
        public string DurationOfRise { get; set; }
        public string DurationOfFall { get; set; }
    }

    public class PhreaticWaterDTO : WaterDTO
    {
        public string SiteName { get; set; }
        public double? AvBuriedDepth { get; set; }
        public double? AvElevation { get; set; }
    }

    public class ConfinedWaterDTO : WaterDTO
    {
        public string BoreholeName { get; set; }
        public string SiteName { get; set; }
        public double? TopElevation { get; set; }
        public double? ObservationDepth { get; set; }
        public string StratumName { get; set; }
        public int? Layer { get; set; }
        public double? WaterTable { get; set; }
        public DateTime? ObservationDate { get; set; }
    }

    public class WaterPropertyDTO : DGObjectDTO
    {
        public string BoreholeName { get; set; }
        public double? Cl { get; set; }
        public double? SO4 { get; set; }
        public double? Mg { get; set; }
        public double? NH { get; set; }
        public double? pH { get; set; }
        public double? CO2 { get; set; }
        public string Corrosion { get; set; }
    }
}