using SqlSugar;


namespace Rayson.Models.Entity
{
    /// <summary>
    /// 功能菜单和按钮
    /// </summary>
    [SugarTable("Sys_Menu")]
    public class Sys_Menu: Sys_BaseModel
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        [SugarColumn(ColumnName = "ParentId")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string? MenuText { get; set; }

        /// <summary>
        /// 全名称--多级菜单--  一级,二级菜单,三级
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? FullName { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? ControllerName { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? ActionName { get; set; }

        /// <summary>
        /// 菜单类型
        /// 0：菜单功能
        /// 1：按钮功能
        /// </summary>
        public int MenuType { get; set; }

        /// <summary>
        /// 递归类型
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Sys_Menu>? MenuChildList { get; set; }
    }
}
