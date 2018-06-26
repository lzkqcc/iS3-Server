using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using iS3.Server.Repository;
using iS3.Server.Utility;
using iS3.Server.DTO.Monitoring;
using iS3.Server.DTO;
using iS3.Server.Models.Project;

namespace iS3.Server.Controllers
{
    /// <summary>
    /// 地质数据相关接口
    /// </summary>
    [RoutePrefix("api/monitoring")]
    public class MonitoringController : ApiController
    {
        /// <summary>
        /// 根据id获取监测点
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">监测点id</param>
        /// <returns> </returns>
        [Route("monpoint")]
        [HttpGet]
        public MonPointDTO getMonPointById(string project, int id)
        {
            MonitoringRepo repo = new MonitoringRepo(project);
            return repo.getMonPointById(id);
        }

        /// <summary>
        /// 根据id获取监测组
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">监测组id</param>
        /// <returns> </returns>
        [Route("mongroup")]
        [HttpGet]
        public MonGroupDTO getMonGroupById(string project, int id)
        {
            MonitoringRepo repo = new MonitoringRepo(project);
            return repo.getMonGroupById(id);
        }

        /// <summary>
        /// 根据id获取监测项目
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">监测项目id</param>
        /// <returns> </returns>
        [Route("monproject")]
        [HttpGet]
        public MonProjectDTO getMonProjectById(string project, int id)
        {
            MonitoringRepo repo = new MonitoringRepo(project);
            return repo.getMonProjectById(id);
        }
    }
}
