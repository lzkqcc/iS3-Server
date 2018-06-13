using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

using IS3.Core;
using iS3.Server.DTO.Structure;
using IS3.Structure;
using iS3.Server.Repository;
using iS3.Server.Utility;

namespace iS3.Server.Controllers
{
    /// <summary>
    /// 地质数据相关接口
    /// </summary>
    [RoutePrefix("api/structure")]
    public class StructureController : ApiController
    {
        ///// <summary>
        ///// 根据id获取工程柱子信息
        ///// </summary>
        ///// <param name="project">项目名称</param>
        ///// <param name="id">柱子id</param>
        ///// <returns> </returns>
        //[Route("pillar")]
        //[HttpGet]
        //public PillarDTO getPillarById(string project, int id)
        //{
        //    throw new iS3Exception("NOT Implementation");

        //    Pillar p = getObjectById<Pillar>(project, id);
        //    return Mapper.Map<PillarDTO>(p);
        //}

        ///// <summary>
        ///// 获取Project工程的所有柱子
        ///// </summary>
        ///// <param name="project">工程名称</param>
        ///// <returns></returns>
        //[Route("pillar")]
        //[HttpGet]
        //public List<PillarDTO> getBoreholeByProject(string project)
        //{
        //    throw new iS3Exception("NOT Implementation");

        //    List<Pillar> ps = getAllByProject<Pillar>(project);
        //    return Mapper.Map<List<PillarDTO>>(ps);
        //}

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
