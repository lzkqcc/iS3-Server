using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Project
{
    public class GISMapDTO
    {
        public string MapID { get; set; }
        public string LocalTileFileName1 { get; set; }
        public string LocalTileFileName2 { get; set; }
        public string LocalMapFileName { get; set; }
        public string LocalGeoDbFileName { get; set; }
        public string MapUrl { get; set; }
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public double MinimumResolution { get; set; }
        public double MapRotation { get; set; }
    }

    public class EngineeringMapDTO : GISMapDTO
    {
        public bool Calibrated { get; set; }
        public double Scale { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public double ScaleZ { get; set; }

        public List<LayerDefDTO> LocalGdbLayersDef { get; set; }
    }
}