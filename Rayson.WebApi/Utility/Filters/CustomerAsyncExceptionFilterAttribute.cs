using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rayson.Common.ResultData;
using System.Collections.Generic;

namespace Rayson.WebApi.Utility.Filters
{
    /// <summary>
    /// 异常处理
    /// </summary>
    public class CustomerAsyncExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled==false)
            {
                context.Result = new JsonResult(new ApiDataResult<string>()
                {
                    Success = false,
                    Message = context.Exception.Message

                });
            }
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
