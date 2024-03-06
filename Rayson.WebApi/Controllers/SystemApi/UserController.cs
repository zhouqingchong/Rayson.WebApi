using Microsoft.AspNetCore.Mvc;
using Rayson.BusinessInterface;
using Rayson.Models.Entity;
using Rayson.WebApi.Utility.SwaggerExtension;
using SqlSugar;

namespace Rayson.WebApi.Controllers.SystemApi
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiSwaggerVersion.V1))]  //指定版本
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/{pageIndex:int}/{pageSize:int}")]
        public async Task<JsonResult> GetUserPage([FromServices] IUserService userService, int pageIndex, int pageSize, string? searchString = null)
        {
            Expressionable<Sys_User> expressionable = new Expressionable<Sys_User>();
            expressionable.AndIF(!string.IsNullOrEmpty(searchString), u => u.UserName.Contains(searchString));
            PageData<Sys_User> JsonResult = userService.QueryPage<Sys_User>(expressionable.ToExpression(), pageSize, pageIndex, c => c.UserId, false);
            return new JsonResult(JsonResult);
        }
    }
}
