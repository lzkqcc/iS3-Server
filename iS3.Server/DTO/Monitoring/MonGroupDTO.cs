using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Monitoring
{
    public class MonGroupDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> MonGroupType { get; set; }
        public Nullable<int> MonProjectID { get; set; }
        public string RefSpecifications { get; set; }
        public string PerInfoIDs { get; set; }
        public string Remark { get; set; }
        public List<MonPointDTO> MonPoints { get; set; }
    }
}