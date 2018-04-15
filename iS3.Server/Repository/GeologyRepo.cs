using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IS3.Core;
using IS3.Geology;

namespace iS3.Server.Repository
{
    public class GeologyRepo : DGObjectRepo
    {
        public GeologyRepo(string projectName)
        {
            project = new Project();
            project.loadDefinition(projectName + ".xml");
            domain = project.domains["Geology"];
        }
    }
}