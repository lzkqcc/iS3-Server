using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Monitoring
{
    public class MonPointDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> MonPointType { get; set; }
        public Nullable<decimal> XCoordinate { get; set; }
        public Nullable<decimal> YCoordinate { get; set; }
        public Nullable<decimal> ZCoordinate { get; set; }
        public Nullable<int> MonGroupID { get; set; }
        public string SensorName { get; set; }
        public Nullable<decimal> IniValue { get; set; }
        public Nullable<System.DateTime> STime { get; set; }
        public Nullable<int> PerInfoID { get; set; }
        public string Remark { get; set; }

        public List<MonPointDataDTO> MonDatas { get; set; }
    }
}