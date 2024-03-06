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
                Type[] typeArry = assembly.GetTypes().Where(t=>t.Namespace.Equals("Rayson.Models.Entity")).ToArray();
                client.CodeFirst.InitTables(typeArry);
            }
        }
    }
}
