using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Project
{
    public class Project_ProjectInfoDTO
    {
        public int ID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectAddress { get; set; }
        public List<int> ConstructionUnit { get; set; }
        public List<int> GeologicalSurveyUnit { get; set; }
        public List<int> DesignUnit { get; set; }
        public List<int> SupervisionUnits { get; set; }
        public List<int> GeneralContractUnit { get; set; }
        public Nullable<decimal> ContractAmount { get; set; }
        public Nullable<int> ContractPeriod { get; set; }
        public string Remark { get; set; }
    }
}