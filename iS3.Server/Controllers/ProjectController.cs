using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iS3.Server.Models.Project;
using iS3.Server.Repository;
using iS3.Server.Utility;
using iS3.Server.DTO.Project;
using IS3.Core;

namespace iS3.Server.Controllers
{
    /// <summary>
    /// 工程概况相关接口
    /// </summary>
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {   
        /// <summary>
        /// 根据CODE获取工程信息
        /// </summary>
        /// <param name="CODE">项目CODE</param>
        /// <returns> </returns>
        [Route("list")]
        [HttpGet]
        public System_ProjectList getProjectListById(string CODE)
        {
            ProjectRepo repo = new ProjectRepo();
            System_ProjectList res = repo.GetProjectListByCode(CODE);
            if (res == null)
                throw new iS3Exception("未查询到该工程");
            return res;
        }

        /// <summary>
        /// 添加工程信息
        /// </summary>
        /// <param name="project">System_ProjectList对象</param>
        /// <returns> </returns>
        [Route("list")]
        [HttpPut]
        [Authorize]
        public string putProjectList(System_ProjectList project)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.PutProjectList(project);
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="project">项目对象</param>
        /// <returns></returns>
        [Route("list")]
        [HttpDelete]
        [Authorize]
        public string deleteProjectList(SimpleProjectDTO project)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.DeleteProjectList(project.ID, project.CODE);
        }

        /// <summary>
        /// 获取模块信息
        /// </summary>
        /// <returns></returns>
        [Route("module")]
        [HttpGet]
        public List<System_ModuleInfo> getProjectListById()
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.GetModule(); 
        }

        /// <summary>
        /// 创建项目信息数据
        /// </summary>
        /// <param name="code">项目code</param>
        /// <param name="info">Project_ProjectInfo对象</param>
        /// <returns></returns>
        [Route("info/{code}")]
        [HttpPut]
        [Authorize]
        public string putProjectInfo(string code, Project_ProjectInfoDTO info)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.PutProjectInfo(code, info);
        }

        /// <summary>
        /// 获取项目信息数据
        /// </summary>
        /// <param name="CODE">项目CODE</param>
        /// <returns></returns>
        [Route("info/{CODE}")]
        [HttpGet]
        public Project_ProjectInfoDTO getProjectInfo(string CODE)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.GetProjectInfo(CODE);
        }

        /// <summary>
        /// 获取单位信息数据
        /// </summary>
        /// <param name="CODE">项目CODE</param>
        /// <returns></returns>
        [Route("unit/{CODE}")]
        [HttpGet]
        public List<Project_UnitInfo> geProjectUnit(string CODE)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.GetProjectUnit(CODE);
        }

        /// <summary>
        /// 根据项目CODE获取ProjectDefinition
        /// </summary>
        /// <param name="CODE">项目CODE</param>
        /// <returns></returns>
        [Route("definition/{CODE}")]
        [HttpGet]
        public ProjectDefinitionDTO getProjectDefiniton(string CODE)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.GetProjectDefinition(CODE);
        }

        /// <summary>
        /// 根据项目CODE获取Domain
        /// </summary>
        /// <param name="CODE">项目CODE</param>
        /// <returns></returns>
        [Route("domain/{CODE}")]
        [HttpGet]
        public Dictionary<string, DomainDTO> getProjectDomains(string CODE)
        {
            ProjectRepo repo = new ProjectRepo();
            return repo.GetProjectDomains(CODE);
        }
    }
}
