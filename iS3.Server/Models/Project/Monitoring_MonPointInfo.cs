//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iS3.Server.Models.Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Monitoring_MonPointInfo
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
    }
}
