using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iS3.Server.Models.Project;

namespace iS3.Server.Repository
{
    public class ProjectRepo
    {
        ProjectContext db;

        public ProjectRepo()
        {
            db = new ProjectContext();
        }

        public ProjectList GetProjectListById(int id)
        {   
            var query = from p in db.ProjectLists
                        where p.ID == id.ToString()
                        select p;
            return query.FirstOrDefault();
        }

        public bool PutProjectList(ProjectList p)
        {
            var res = db.ProjectLists.Add(p);
            if (res == null) return false;
            db.SaveChanges(); 
            return true;
        }
    }
}