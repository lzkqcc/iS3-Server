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
    
    public partial class Structure_Tunnels
    {
        public int ID { get; set; }
        public Nullable<int> OBJECTID { get; set; }
        public byte[] Shape { get; set; }
        public Nullable<double> Shape_Length { get; set; }
        public Nullable<double> Shape_Area { get; set; }
        public Nullable<int> LineNo { get; set; }
        public string Description { get; set; }
        public Nullable<double> StartMileage { get; set; }
        public Nullable<double> EndMileage { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Height { get; set; }
        public string ShapeDesc { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> ConBeginDate { get; set; }
        public Nullable<System.DateTime> ConEndDate { get; set; }
    }
}