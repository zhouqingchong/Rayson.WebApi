using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rayson.BusinessInterface;
using Rayson.Common.ResultData;
using Rayson.Models.DTO;
using Rayson.Models.Entity;
using Rayson.WebApi.Utility.Filters;
using Rayson.WebApi.Utility.InitDataBaseExtension;
using Rayson.WebApi.Utility.SwaggerExtension;
using SqlSugar;

namespace Rayson.WebApi.Controllers.SystemApi
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [CustomerAsyncExceptionFilter]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiSwaggerVersion.V1))]  //指定版本
    [ActionControllerAttribute(MenuType.Page,"用户管理")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 查询用户分页
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/{pageIndex:int}/{pageSize:int}")]
        [ActionControllerAttribute(MenuType.Btn, "查询用户")]
        public async Task<JsonResult> GetUserPage([FromServices] IUserService userService, [FromServices] IMapper mapper, int pageIndex, int pageSize, string? searchString = null)
        {
            Expressionable<Sys_User> expressionable = new Expressionable<Sys_User>();
            expressionable.AndIF(!string.IsNullOrEmpty(searchString), u => u.UserName.Contains(searchString));
            PageData<Sys_User> JsonResult = userService.QueryPage<Sys_User>(expressionable.ToExpression(), pageSize, pageIndex, c => c.UserId, false);

            ApiDataResult<PageData<SysUserDTO>> result = new ApiDataResult<PageData<SysUserDTO>>()
            {
                Data = mapper.Map<PageData<Sys_User>, PageData<SysUserDTO>>(JsonResult),
                Success=true,
                Message="用户分页查询"
            };
            return await Task.FromResult(new JsonResult(result));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="mapper"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [CustomerAsyncValidataParaActionFilterAttribute]
        public async Task<JsonResult> AddUser([FromServices] IUserService userService, [FromServices] IMapper mapper, SysUserDTO user)
        {
            Sys_User adduser = mapper.Map<SysUserDTO, Sys_User>(user);
            //adduser.PassWord = MD5Encrypt.Encrypt(adduser.PassWord);
            userService.Insert(adduser);
            var result = new JsonResult(new ApiDataResult<Sys_User>()
            {
                Data = adduser,
                Success = true,
                Message = "添加用户"
            });
            return await Task.FromResult(result);
        }

    }
}
