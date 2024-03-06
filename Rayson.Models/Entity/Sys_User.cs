using SqlSugar;

namespace Rayson.Models.Entity
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Sys_User
    {
        /// <summary>
        /// 数据库映射主键自增
        /// </summary>
        [SugarColumn(ColumnName = "UserId", IsIdentity = true, IsPrimaryKey = true)]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public int Status { get; set; }
        public int Sex { set; get; }
        public string Mobile { get; set; }
        public string? Address { get; set; }
        public string? Email { set; get; }
        public long QQ { set; get; }
        public string? WeChat { set; get; }
        public DateTime LastLoginTime { set; get; }

    }
}
