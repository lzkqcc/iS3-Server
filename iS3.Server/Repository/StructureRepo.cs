﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Core;
using IS3.Structure;

namespace iS3.Server.Repository
{
    public class StructureRepo : DGObjectRepo
    {
        public StructureRepo(string projectName)
        {
            project = CentralRepo.getProject(projectName);
            domain = project.domains["Structure"];
        }
    }
}