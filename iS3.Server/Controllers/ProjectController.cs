using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iS3.Server.Models.Project;
using iS3.Server.Repository;

namespace iS3.Server.Controllers
{
    /// <summary>
    /// 工程概况相关接口
    /// </summary>
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        /// <summary>
        /// 根据id获取工程信息
        /// </summary>
        /// <param name="id">项目名称</param>
        /// <param name="id">钻孔id</param>
        /// <returns> </returns>
        [Route("info")]
        [HttpGet]
        public ProjectList getProjectListById(int id)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.GetProjectListById(id);
        }

        /// <summary>
        /// 添加工程信息
        /// </summary>
        /// <param name="id">项目名称</param>
        /// <param name="id">钻孔id</param>
        /// <returns> </returns>
        [Route("info")]
        [HttpPut]
        [Authorize]
        public bool putProjectList(ProjectList p)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.PutProjectList(p);
        }
    }
}
