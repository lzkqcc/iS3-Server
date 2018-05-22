using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Project
{
    public class ProjectDefinitionDTO
    {
        public string ID { get; set; }
        public string ProjectTitle { get; set; }
        public string DefaultMapID { get; set; }
        public string LocalFilePath { get; set; }
        public string LocalTilePath { get; set; }
        public string LocalDatabaseName { get; set; }
        public string DataServiceUrl { get; set; }
        public string GeometryServiceUrl { get; set; }
    }
}