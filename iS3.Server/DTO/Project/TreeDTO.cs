using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO.Project
{
    public class TreeDTO
    {

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string RefDomainName { get; set; }
        public string RefObjsName { get; set; }
        public string Filter { get; set; }
        public string Sort { get; set; }
        public List<TreeDTO> Children { get; set; }
    }
}