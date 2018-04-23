using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iS3.Server.Models.Project;
using iS3.Server.Utility;

namespace iS3.Server.Repository
{
    public class ProjectRepo
    {
        DB_iS3Context db;

        public ProjectRepo()
        {
            db = new DB_iS3Context();
        }

        public System_ProjectList GetProjectListById(int id)
        {   
            var query = from p in db.System_ProjectList
                        where p.ID == id
                        select p;
            return query.FirstOrDefault();
        }

        public bool PutProjectList(System_ProjectList p)
        {
            if (p.ID == null)
                throw new iS3Exception("项目ID不能为空");
            
            if (p.CODE == null)
                throw new iS3Exception("项目代号不能为空");

            var res = db.System_ProjectList.Add(p);
            db.SaveChanges();

            DB_iS3_ProjectContext ctx = new DB_iS3_ProjectContext("DB_iS3_" + p.CODE);
            ctx.Database.CreateIfNotExists();

            return true;
        }

        public bool DeleteProjectList(System_ProjectList p)
        {
            if (p.ID == null)
                throw new iS3Exception("项目ID不能为空");

            if (p.CODE == null)
                throw new iS3Exception("项目代号不能为空");

            db.System_ProjectList.Attach(p);
            db.System_ProjectList.Remove(p);
            db.SaveChanges();

            DB_iS3_ProjectContext ctx = new DB_iS3_ProjectContext("DB_iS3_" + p.CODE);
            ctx.Database.Delete();

            return true;
        }
    }
}