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

        public RiverWaterDTO() { }
        public RiverWaterDTO(RiverWater rw)
        {
            id = rw.id;
            name = rw.name;
            fullName = rw.fullName;
            description = rw.description;
            ObservationLocation = rw.ObservationLocation;
            HighestTidalLevel = rw.HighestTidalLevel;
            LowestTidalLevel = rw.LowestTidalLevel;
            AvHighTidalLevel = rw.AvHighTidalLevel;
            AvLowTidalLevel = rw.AvLowTidalLevel;
            AvTidalRange = rw.AvTidalRange;
            HighestTidalLevelDate = rw.HighestTidalLevelDate;
            LowestTidalLevelDate = rw.LowestTidalLevelDate;
            DurationOfRise = rw.DurationOfRise;
            DurationOfFall = rw.DurationOfFall;
        }
    }

    public class PhreaticWaterDTO : WaterDTO
    {
        public string SiteName { get; set; }
        public double? AvBuriedDepth { get; set; }
        public double? AvElevation { get; set; }

        public PhreaticWaterDTO() { }
        public PhreaticWaterDTO(PhreaticWater pw)
        {
            id = pw.id;
            name = pw.name;
            fullName = pw.fullName;
            description = pw.description;
            SiteName = pw.SiteName;
            AvBuriedDepth = pw.AvBuriedDepth;
            AvElevation = pw.AvElevation;
        }
        public static List<PhreaticWaterDTO> transferList(List<PhreaticWater> pws)
        {
            List<PhreaticWaterDTO> res = new List<PhreaticWaterDTO>();
            foreach (PhreaticWater pw in pws) res.Add(new PhreaticWaterDTO(pw));
            return res;
        }
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

        public ConfinedWaterDTO() { }
        public ConfinedWaterDTO(ConfinedWater cw)
        {
            id = cw.id;
            name = cw.name;
            fullName = cw.fullName;
            description = cw.description;
            BoreholeName = cw.BoreholeName;
            SiteName = cw.SiteName;
            TopElevation = cw.TopElevation;
            ObservationDepth = cw.ObservationDepth;
            StratumName = cw.StratumName;
            Layer = cw.Layer;
            WaterTable = cw.WaterTable;
            ObservationDate = cw.ObservationDate;
        }
        public static List<ConfinedWaterDTO> transferList(List<ConfinedWater> pws)
        {
            List<ConfinedWaterDTO> res = new List<ConfinedWaterDTO>();
            foreach (ConfinedWater pw in pws) res.Add(new ConfinedWaterDTO(pw));
            return res;
        }
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

        public WaterPropertyDTO() { }
        public WaterPropertyDTO(WaterProperty wp)
        {
            id = wp.id;
            name = wp.name;
            fullName = wp.fullName;
            description = wp.description;
            BoreholeName = wp.BoreholeName;
            Cl = wp.Cl;
            SO4 = wp.SO4;
            Mg = wp.Mg;
            NH = wp.NH;
            pH = wp.pH;
            CO2 = wp.CO2;
            Corrosion = wp.Corrosion;
        }
        public static List<WaterPropertyDTO> transferList(List<WaterProperty> pws)
        {
            List<WaterPropertyDTO> res = new List<WaterPropertyDTO>();
            foreach (WaterProperty pw in pws) res.Add(new WaterPropertyDTO(pw));
            return res;
        }
    }
}