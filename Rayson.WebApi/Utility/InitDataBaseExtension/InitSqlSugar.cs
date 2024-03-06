using SqlSugar;

namespace Rayson.WebApi.Utility.InitDataBaseExtension
{

    /// <summary>
    /// 初始化sqlsugar
    /// </summary>
    public static class InitSqlSugar
    {
        /// <summary>
        /// 配置初始化
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="Exception"></exception>
        public static void AddInitSqlSugar(this WebApplicationBuilder builder)
        {
            //读取配置文件中的数据库链接字符串
            string? connectionString = builder.Configuration.GetConnectionString("ConnectionString");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("请配置数据库链接字符串~");
            }
            ConnectionConfig connection = new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            };

            builder.Services.AddScoped<ISqlSugarClient>(s =>
            {
                SqlSugarClient client = new SqlSugarClient(connection);

                //配置对于数据库操作的过滤器
                client.Aop.OnLogExecuting = (s, p) =>
                {
                    Console.WriteLine($"OnLogExecuting:输出Sql语句：{s} ||参数为：{string.Join(",", p.Select(p => p.Value))}");
                };
                client.Aop.OnExecutingChangeSql = (s, p) =>
                {
                    Console.WriteLine($"OnExecutingChangeSql:输出Sql语句：{s} ||参数为：{string.Join(",", p.Select(p => p.Value))}");
                    return new KeyValuePair<string, SugarParameter[]>(s, p);
                };
                client.Aop.OnLogExecuted = (s, p) =>
                {
                    Console.WriteLine($"OnLogExecuted:输出Sql语句：{s} ||参数为：{string.Join(",", p.Select(p => p.Value))}");
                };

                client.Aop.OnError = e =>
                {
                    Console.WriteLine($"OnError:Sql语句执行异常：{e.Message}");
                };
                return client;
            });
        }
    }
}
