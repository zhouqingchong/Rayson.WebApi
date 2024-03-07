using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rayson.Common.ResultData;
using Rayson.Common.ValidateRules;
using Rayson.Models.DTO;
using System.Reflection;

namespace Rayson.WebApi.Utility.Filters
{
    /// <summary>
    /// 参数校验
    /// </summary>
    public class CustomerAsyncValidataParaActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //验证业务逻辑（验证参数）
            List<object?> paramterList = context.ActionArguments
                .Where(p => p.Value is BaseDTO && p.Value is not null)
                .Select(c => c.Value).ToList();

            List<(bool, string)> list = new List<(bool, string)>();
            foreach (var item in paramterList)
            {
                //通过特性进行实体验证
                foreach (var prop in item.GetType().GetProperties().Where(p => p.IsDefined(typeof(BaseAbstractAttribute), true)))
                {
                    BaseAbstractAttribute? attribute = prop.GetCustomAttribute<BaseAbstractAttribute>();
                    list.Add(attribute.DoValidate(prop.GetValue(item)));
                }
            }

            if (list.Any(c=>c.Item1==false))
            {
                context.Result = new JsonResult(new ApiDataResult<string>()
                {
                    Success=false,
                    Message=string.Join(",",list.Where(c=>c.Item1==false).Select(c=>c.Item2))

                });
            }
            else
            {
                await next();
            }
        }
    }
}
