using Rayson.Common.ValidateRules;

namespace Rayson.Models.DTO
{
    public class SysUserDTO: BaseDTO
    {
        public int UserId { get; set; }

        [RaysonRequiredAttribute("用户名称不能为空")]
        public string? Name { get; set; }
        public string? PassWord { get; set; }
        public int Status { get; set; }
        public int Sex { set; get; }
        public string Mobile { get; set; }
        [RaysonRequiredAttribute("用户地址不能为空")]
        public string? Address { get; set; }
        public string? Email { set; get; }

        [RequireIsNumActtribute("QQ号必须为数字")]
        public long QQ { set; get; }
        public string? WeChat { set; get; }
        public DateTime LastLoginTime { set; get; }
    }
}
