using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;

using iS3.Server.Models;

namespace iS3.Server.Filters
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 将返回数据中的data包装成统一IS3Result格式
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // 若发生异常不处理
            if (actionExecutedContext.Exception != null)
                return;

            base.OnActionExecuted(actionExecutedContext);

            var code = actionExecutedContext.ActionContext.Response.StatusCode;
            object data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;

            actionExecutedContext.Response = actionExecutedContext.Request
                .CreateResponse(code, new iS3Result(true, data, String.Empty));
        }
    }
}