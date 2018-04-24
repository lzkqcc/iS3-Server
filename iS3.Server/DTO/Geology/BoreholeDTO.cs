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

        public BoreholeGeologyDTO() { }
        public BoreholeGeologyDTO(BoreholeGeology bg)
        {
            Top = bg.Top;
            Base = bg.Base;
            StratumID = bg.StratumID;
        }
    }
    
    public class BoreholeDTO : DGObjectDTO
    {
        public double Top { get; set; }
        public double Base { get; set; }
        public double? Mileage { get; set; }
        public string Type { get; set; }
        public List<BoreholeGeologyDTO> geologies { get; set; }

        public BoreholeDTO() { geologies = new List<BoreholeGeologyDTO>(); }
        public BoreholeDTO(Borehole b) : this()
        {
            id = b.id;
            Top = b.Top;
            Base = b.Base;
            Mileage = b.Mileage;
            Type = b.Type;
            foreach (BoreholeGeology bg in b.Geologies)
            {
                geologies.Add(new BoreholeGeologyDTO(bg));
            }
        }

        public static List<BoreholeDTO> transferList(List<Borehole> boreholes)
        {
            List<BoreholeDTO> res = new List<BoreholeDTO>();
            foreach(Borehole b in boreholes) res.Add(new BoreholeDTO(b));
            return res;
        }
    }
}