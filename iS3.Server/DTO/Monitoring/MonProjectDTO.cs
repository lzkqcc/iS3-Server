using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Monitoring
{
    public class MonProjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<int> PerInfoID { get; set; }
        public string MonInstInfoIDs { get; set; }
        public string PlanFile { get; set; }
        public string Remark { get; set; }
        public List<MonGroupDTO> MonGroups { get; set; }
    }
}