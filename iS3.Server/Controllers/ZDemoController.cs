using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using iS3.Server.Models.Geology;
using iS3.Server.Utility;

namespace iS3.Server.Controllers
{
    /// <summary>
    /// 一些测试接口
    /// </summary>
    [RoutePrefix("api/demo")]
    public class ZDemoController : ApiController
    {
        Demo[] boreholes = new Demo[] 
        {
            new Demo(1, "b1", 3.33, true),
            new Demo(2, "b2", 2.33, false)
        };

        /// <summary>
        /// 根据id获取钻孔数据
        /// </summary>
        /// <param name="id">钻孔id</param>
        /// <returns>
        /// id：钻孔id号；name：钻孔名称；deep：钻孔深度；isVisible：钻孔是否可见
        /// </returns>
        [Route("example/{id}")]
        [HttpGet]
        public Demo Borehole(int id)
        {
            Demo b = boreholes.FirstOrDefault((p) => p.id == id);
            if (b == null)
            {
                throw new iS3Exception(string.Format("没有找到id={0}的对象", id));
            }
            return b;
        }

        /// <summary>
        /// 根据id获取钻孔数据（授权）
        /// </summary>
        /// <param name="id">钻孔id</param>
        /// <returns>
        /// id：钻孔id号；name：钻孔名称；deep：钻孔深度；isVisible：钻孔是否可见
        /// </returns>
        [Route("example2/{id}")]
        [HttpGet]
        [Authorize]
        public Demo Borehole2(int id)
        {
            Demo b = boreholes.FirstOrDefault((p) => p.id == id);
            if (b == null)
            {
                throw new Exception(string.Format("没有找到id={0}的对象", id));
            }
            return b;
        }
    }
}
