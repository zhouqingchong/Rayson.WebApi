using AutoMapper;
using Rayson.Models.DTO;
using Rayson.Models.Entity;

namespace Rayson.BusinessInterface.MapConfig
{
    public class AutoMapperConfigs : Profile
    {
        /// <summary>
        /// 配置映射关系，在实例化当前这个类的时候，就要处理好
        /// </summary>
        public AutoMapperConfigs()
        {
            CreateMap<Sys_User,SysUserDTO>().ReverseMap();
            CreateMap<PageData<Sys_User>, PageData<SysUserDTO>>().ReverseMap();
        }
    }
}
