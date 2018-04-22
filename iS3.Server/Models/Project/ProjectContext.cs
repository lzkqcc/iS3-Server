using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace iS3.Server.Models.Project
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=DefaultConnection") { }

        public DbSet<ProjectList> ProjectLists { get; set; }
    }
}