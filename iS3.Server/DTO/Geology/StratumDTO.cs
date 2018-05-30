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

        public StratumDTO() { }
        public StratumDTO(Stratum st)
        {
            id = st.id;
            name = st.name;
            fullName = st.name;
            description = st.description;
            GeologyAge = st.GeologyAge;
            FormationType = st.FormationType;
            Compaction = st.Compaction;
            ElevationRange = st.ElevationRange;
            ThicknessRange = st.ThicknessRange;
        }

        public static List<StratumDTO> transferList(List<Stratum> stratum)
        {
            List<StratumDTO> res = new List<StratumDTO>();
            foreach (Stratum st in stratum) res.Add(new StratumDTO(st));
            return res;
        }
    }
}