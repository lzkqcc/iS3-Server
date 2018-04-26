using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iS3.Server.Models.Project;
using iS3.Server.Utility;
using iS3.Server.DTO.Project;
using System.Text;
using AutoMapper;

namespace iS3.Server.Repository
{
    public class ProjectRepo
    {
        DB_iS3Context db;

        public ProjectRepo()
        {
            db = new DB_iS3Context();
        }

        public System_ProjectList GetProjectListByCode(string code)
        {   
            var query = from p in db.System_ProjectList
                        where p.CODE == code
                        select p;
            return query.FirstOrDefault();
        }

        public string PutProjectList(System_ProjectList p)
        {
            if (p.ID != 0)
                throw new iS3Exception("不准赋值ID");
            
            if (p.CODE == null)
                throw new iS3Exception("项目代号不能为空");

            var tmp = db.System_ProjectList.FirstOrDefault(t => t.CODE == p.CODE);
            if (tmp != null)
                throw new iS3Exception("项目代号重复");

            int maxID = db.System_ProjectList.Max(t => t.ID);
            p.ID = maxID + 1;

            var res = db.System_ProjectList.Add(p);
            db.SaveChanges();

            DB_iS3_ProjectContext ctx = new DB_iS3_ProjectContext(p.CODE);
            ctx.Database.CreateIfNotExists();

            return "创建成功";
        }

        public string DeleteProjectList(int id, string code)
        {
            if (id == null)
                throw new iS3Exception("项目ID不能为空");

            if (code == null)
                throw new iS3Exception("项目代号不能为空");

            var deleteRec = db.System_ProjectList.FirstOrDefault(pro => pro.ID == id && pro.CODE.Equals(code));
            if (deleteRec == null)
            {
                throw new iS3Exception("未找到该工程");
            }
            db.System_ProjectList.Remove(deleteRec);
            db.SaveChanges();

            DB_iS3_ProjectContext ctx = new DB_iS3_ProjectContext(code);
            ctx.Database.Delete();

            return "删除成功";
        }

        public List<System_ModuleInfo> GetModule()
        {
            return db.System_ModuleInfo.ToList();
        }

        public string PutProjectInfo(string code, Project_ProjectInfoDTO info)
        {
            DB_iS3_ProjectContext ctx = new DB_iS3_ProjectContext(code);
            Project_ProjectInfo obj = Mapper.Map<Project_ProjectInfo>(info);
            if (ctx.Project_ProjectInfo.Count() == 0)
                obj.ID = 1;
            else
            {
                int maxID = ctx.Project_ProjectInfo.Max(t => t.ID);
                obj.ID = maxID + 1;
            }
            
            ctx.Project_ProjectInfo.Add(obj);
            ctx.SaveChanges();
            return "成功";
        }

        public Project_ProjectInfoDTO GetProjectInfo(string code)
        {
            DB_iS3_ProjectContext ctx = new DB_iS3_ProjectContext(code);
            List<Project_ProjectInfo> obj = ctx.Project_ProjectInfo.ToList();
            if (obj == null || obj.Count == 0) return null;
            return Mapper.Map<Project_ProjectInfoDTO>(obj[0]);
        }

        public List<Project_UnitInfo> GetProjectUnit(string code)
        {
            return db.Project_UnitInfo.ToList();
        }
    }
}