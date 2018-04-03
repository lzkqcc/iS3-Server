using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using iS3.Server.Models.Geology;

namespace iS3.Server.Controllers
{
    [RoutePrefix("api/geology")]
    public class GeologyController : ApiController
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
        [Route("demo/{id}")]
        [HttpGet]
        public Demo Borehole(int id)
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
