using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Monitoring
{
    public class MonPointDataDTO
    {
        public int ID { get; set; }
        public Nullable<int> MonPointID { get; set; }
        public Nullable<decimal> Reading { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<System.DateTime> DataTime { get; set; }
        public Nullable<System.DateTime> SysTime { get; set; }
    }
}