using System.Drawing.Drawing2D;

namespace Rayson.WebApi.Utility.Filters
{
    public class ActionControllerAttribute : Attribute
    {
        private string _Description;
        private MenuType _menuType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuType"></param>
        /// <param name="Description"></param>
        public ActionControllerAttribute(MenuType menuType, string Description)
        {
            _menuType = menuType;
            _Description = Description;
        }

        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public string GetDescription() => _Description;
        /// <summary>
        /// 功能类型
        /// </summary>
        /// <returns></returns>
        public MenuType GetMenuType() => _menuType;
    }

    /// <summary>
    /// 类型
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 一级菜单页面
        /// </summary>
        Page = 1,
        /// <summary>
        /// 按钮功能
        /// </summary>
        Btn = 2
    }
}
