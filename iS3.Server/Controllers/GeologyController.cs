using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using iS3.Server.Repository;
using IS3.Geology;
using iS3.Server.Utility;
using iS3.Server.DTO.Geology;

namespace iS3.Server.Controllers
{
    /// <summary>
    /// 地质数据相关接口
    /// </summary>
    [RoutePrefix("api/geology")]
    public class GeologyController : ApiController
    {
        /// <summary>
        /// 根据id获取工程钻孔数据
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">钻孔id</param>
        /// <returns> </returns>
        [Route("borehole")]
        [HttpGet]
        public BoreholeDTO getBoreholeById(string project, int id)
        {
            if (!FileUtil.projectExit(project))
                throw new iS3Exception(string.Format("{0}工程不存在", project));

            GeologyRepo repo = new GeologyRepo(project);
            Borehole b = repo.getBoreholeById(id);

            if ( b == null)
                throw new iS3Exception(string.Format("没有找到id={0}的对象", id));
            return new BoreholeDTO(b);
        }

        /// <summary>
        /// 获取Project工程的所有钻孔
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("borehole")]
        [HttpGet]
        public List<BoreholeDTO> getBoreholeByProject(string project)
        {
            if (!FileUtil.projectExit(project))
                throw new iS3Exception(string.Format("{0}工程不存在", project));

            GeologyRepo repo = new GeologyRepo(project);
            List<Borehole> bs = repo.getAllBorehole();

            if (bs == null)
                throw new iS3Exception(string.Format("没有找到{0}工程的钻孔数据", project));
            return BoreholeDTO.transferList(bs);
        }
    }
}
