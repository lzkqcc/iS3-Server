using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IS3.Core;

namespace iS3.Server.DTO.Project
{
    public class DomainDTO
    {
        public string name { get; set; }
        public TreeDTO root { get; set; }
        public Dictionary<string, DGObjectsDefinition>
            objsDefinitions { get; set; }
    }
}