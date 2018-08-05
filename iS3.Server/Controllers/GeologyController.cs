using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

using iS3.Server.Repository;
using IS3.Geology;
using iS3.Server.Utility;
using iS3.Server.DTO.Geology;
using iS3.Server.DTO;
using IS3.Core;
using iS3.Server.Models.Project;

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
            //Borehole b = getObjectById<Borehole>(project, id);
            //return Mapper.Map<BoreholeDTO>(b);
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getBoreholeById(id);
        }

        /// <summary>
        /// 获取Project工程钻孔
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="ids">（可选）钻孔id，如api/geology/borehole?project={project}&amp;ids=1&amp;ids=2，不提供ids默认取所有钻孔</param>
        /// <returns> </returns>
        [Route("borehole")]
        [HttpGet]
        public List<BoreholeDTO> getBoreholeByIds([FromUri]string project, [FromUri]int[] ids)
        {
            GeologyRepo repo = new GeologyRepo(project);
            if (ids.Length == 0)
            {
                //List<Borehole> bs = getAllByProject<Borehole>();
                //return Mapper.Map<List<BoreholeDTO>>(bs);
                return repo.getAllBoreholeByProject();
            }
            else
            {
                //List<Borehole> bs = getObjectByIds<Borehole>(project, ids);
                //return Mapper.Map<List<BoreholeDTO>>(bs);
                return repo.getBoreholeByIds(ids);
            }
        }

        /// <summary>
        /// 根据id获取地层数据
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">地层id</param>
        /// <returns> </returns>
        [Route("stratum")]
        [HttpGet]
        public StratumDTO getStratumById(string project, int id)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getStratumById(id);
        }

        /// <summary>
        /// 获取Project工程的所有地层
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("stratum")]
        [HttpGet]
        public List<StratumDTO> getStratumByProject(string project)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllStratum();
        }

        /// <summary>
        /// 根据id获取地层区间
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">地层区间id</param>
        /// <returns> </returns>
        [Route("stratumsection")]
        [HttpGet]
        public StratumSectionDTO getStratumSectionById(string project, int id)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getStratumSectionById(id);
        }

        /// <summary>
        /// 获取Project工程的所有地层区间
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("stratumsection")]
        [HttpGet]
        public List<StratumSectionDTO> getStratumSectionByProject(string project)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllStratumSection();
        }

        /// <summary>
        /// 根据id获取土层参数
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">土层参数id</param>
        /// <returns> </returns>
        [Route("soilproperty")]
        [HttpGet]
        public SoilPropertyDTO getSoilPropertyById(string project, int id)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getSoilPropertyById(id);
        }

        /// <summary>
        /// 获取Project工程的所有土层参数
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("soilproperty")]
        [HttpGet]
        public List<SoilPropertyDTO> getSoilPropertyByProject(string project)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllSoilProperty();
        }

        /// <summary>
        /// 根据id获取潜水层
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">潜水层id</param>
        /// <returns> </returns>
        [Route("phreaticwater")]
        [HttpGet]
        public PhreaticWaterDTO getPhreaticWaterById(string project, int id)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getPhreaticWaterById(id);
        }

        /// <summary>
        /// 获取Project工程的所有潜水层
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("phreaticwater")]
        [HttpGet]
        public List<PhreaticWaterDTO> getPhreaticWaterByProject(string project)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllPhreaticWater();
        }

        /// <summary>
        /// 根据id获取承压水
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">承压水id</param>
        /// <returns> </returns>
        [Route("confinedwater")]
        [HttpGet]
        public ConfinedWaterDTO getConfinedWaterById(string project, int id)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getConfinedWaterById(id);
        }

        /// <summary>
        /// 获取Project工程的所有承压水
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("confinedwater")]
        [HttpGet]
        public List<ConfinedWaterDTO> getConfinedWaterByProject(string project)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllConfinedWater();
        }

        /// <summary>
        /// 根据id获取地下水参数
        /// </summary>
        /// <param name="project">项目名称</param>
        /// <param name="id">地下水参数id</param>
        /// <returns> </returns>
        [Route("waterproperty")]
        [HttpGet]
        public WaterPropertyDTO getWaterPropertyById(string project, int id)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getWaterPropertyById(id);
        }

        /// <summary>
        /// 获取Project工程的所有承压水
        /// </summary>
        /// <param name="project">工程名称</param>
        /// <returns></returns>
        [Route("WaterProperty")]
        [HttpGet]
        public List<WaterPropertyDTO> getWaterPropertyByProject(string project)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllWaterProperty();
        }
        #region 对象组API

        /// <summary>
        /// 根据对象组筛选条件获取Project工程钻孔
        /// </summary>
        /// <param name="project">工程</param>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        [Route("borehole")]
        [HttpGet]
        public List<BoreholeDTO> getBoreholeByObjs([FromUri]string project, [FromUri]string filter)
        {
            GeologyRepo repo = new GeologyRepo(project);
            return repo.getAllBoreholeByObjs(filter);
        }

        #endregion
        // Code used for iS3 core. By now, customed EF is used.

        //private T getObjectById<T>(string project, int id) 
        //    where T : DGObject
        //{
        //    if (!FileUtil.projectExit(project))
        //        throw new iS3Exception(string.Format("{0}工程不存在", project));

        //    GeologyRepo repo = new GeologyRepo(project);
        //    T obj = repo.getObjectById<T>(id);

        //    if (obj == null)
        //        throw new iS3Exception(string.Format("没有找到id={0}的对象", id));

        //    return obj;
        //}

        //private List<T> getObjectByIds<T>(string project, int[] ids)
        //  where T : DGObject, new()
        //{
        //    if (!FileUtil.projectExit(project))
        //        throw new iS3Exception(string.Format("{0}工程不存在", project));

        //    GeologyRepo repo = new GeologyRepo(project);

        //    List<T> objs = new List<T>();
        //    foreach (int id in ids)
        //    {
        //        T obj = repo.getObjectById<T>(id);
        //        if (obj == null)
        //        {
        //            T obj1 = new T();
        //            obj1.id = id;
        //            objs.Add((T)obj1);
        //        }
        //        else
        //            objs.Add((T)obj);
        //    }
        //    return objs;
        //}

        //private List<T> getAllByProject<T>(string project)
        //    where T : DGObject
        //{
        //    if (!FileUtil.projectExit(project))
        //        throw new iS3Exception(string.Format("{0}工程不存在", project));

        //    GeologyRepo repo = new GeologyRepo(project);
        //    List<T> objs = repo.getAllObjects<T>();

        //    if (objs == null)
        //        throw new iS3Exception(string.Format("没有找到{0}工程的钻孔数据", project));
        //    return objs;
        //}
    }
}
