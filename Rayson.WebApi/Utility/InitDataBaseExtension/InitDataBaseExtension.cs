using Microsoft.AspNetCore.Mvc;
using Rayson.Models.Entity;
using Rayson.WebApi.Utility.Filters;
using SqlSugar;
using System.Reflection;

namespace Rayson.WebApi.Utility.InitDataBaseExtension
{
    /// <summary>
    /// 初始化SqlSugar
    /// </summary>
    public static class InitDataBaseExtension
    {
        /// <summary>
        /// 配置sqlsugar
        /// </summary>
        /// <param name="builder"></param>
        public static void InitDataBase(this WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("Connectionstring");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("请配置数据库连接字符串");
            }

            List<Sys_Menu> menuList = new List<Sys_Menu>();
            Assembly asy = Assembly.GetExecutingAssembly();
            var controllerActionList = asy.GetTypes()
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t));

            foreach (var controller in controllerActionList.Where(p => p.IsDefined(typeof(ActionControllerAttribute), true)))
            {
                ActionControllerAttribute? attribute = controller.GetCustomAttribute<ActionControllerAttribute>();
                Guid guid = Guid.NewGuid();

                Sys_Menu _Menu = new Sys_Menu()
                {
                    Id = guid,
                    ParentId = default,
                    MenuText = attribute?.GetDescription(),
                    MenuType = attribute is null ? (int)MenuType.Page : (int)attribute.GetMenuType()
                };
                menuList.Add(_Menu);


                foreach (var method in controller.GetMethods().Where(m => m.IsDefined(typeof(ActionControllerAttribute), true)))
                {
                    ActionControllerAttribute? attrobute = controller.GetCustomAttribute<ActionControllerAttribute>();

                    Sys_Menu methodMenu = new Sys_Menu()
                    {
                        Id = Guid.NewGuid(),
                        ParentId = guid,
                        FullName=$"{controller.Name}.{method.Name}",
                        MenuText = attrobute?.GetDescription(),
                        MenuType = attrobute is null ? (int)MenuType.Btn : (int)attrobute.GetMenuType(),
                        ControllerName= controller.Name.ToLower().Replace("controller",""),
                        ActionName= method.Name.ToLower()
                    };
                    menuList.Add(methodMenu);
                }
            }




            ConnectionConfig connection = new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true //是否自动关闭连接
            };

            using (SqlSugarClient client = new SqlSugarClient(connection))
            {
                client.DbMaintenance.CreateDatabase();
                Assembly assembly = Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, "Rayson.Models.dll"));
                Type[] typeArry = assembly.GetTypes().Where(t => !t.Name.Equals("Sys_BaseModel") && t.Namespace.Equals("Rayson.Models.Entity")).ToArray();

                client.CodeFirst.InitTables(typeArry);
                client.Insertable(menuList).ExecuteCommand();
            }
        }
    }
}
