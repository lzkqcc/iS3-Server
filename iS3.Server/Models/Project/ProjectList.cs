using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Server.Models.Project
{
    [Table("Sys_ProjectListInfo")]
    public class ProjectList
    {
        public string ID { get; set; }
        public string DefinitionFile { get; set; }
        public bool DefaultMap { get; set; }
        public string Description { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Name { get; set; }
        public Nullable<int> DBType { get; set; }
        public string DBName { get; set; }
        public string DBUser { get; set; }
        public string DBPassword { get; set; }
        public string FileService { get; set; }
        public string AnalysisService { get; set; }
    }
}