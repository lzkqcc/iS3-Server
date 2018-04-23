using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;

using iS3.Server.Models;

namespace iS3.Server.Filters
{
    public class ApiErrorHandleAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// API发生错误时拦截处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            // 取得异常错误信息
            String errorMessage = actionExecutedContext.Exception.Message;

            iS3Result result = new iS3Result(false, null, errorMessage);

            actionExecutedContext.Response = actionExecutedContext.Request
                .CreateResponse(System.Net.HttpStatusCode.OK, result);
        }
    }
}