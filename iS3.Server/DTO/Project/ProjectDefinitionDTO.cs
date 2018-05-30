using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Project
{
    public class ProjectInformationDTO
    {

        public string ID { get; set; }
        public double Length { get; set; }
        public double OuterDiameter { get; set; }
        public double InnerDiamter { get; set; }
    }

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

        public List<ProjectInformationDTO> SubProjectInfos { get; set; }
        public List<EngineeringMapDTO> EngineeringMaps { get; set; }
    }
}