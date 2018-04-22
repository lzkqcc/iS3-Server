using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Structure;

namespace iS3.Server.DTO.Structure
{
    public class PillarDTO : DGObjectDTO
    {
        public int ObjID { get; set; }

        public PillarDTO() { }
        public PillarDTO(Pillar p)
            : this()
        {
            ObjID = p.ObjID;
        }

        public static List<PillarDTO> transferList(List<Pillar> pillars)
        {
            List<PillarDTO> res = new List<PillarDTO>();
            foreach (Pillar p in pillars) res.Add(new PillarDTO(p));
            return res;
        }
    }
}