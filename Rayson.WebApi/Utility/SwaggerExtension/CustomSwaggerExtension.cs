using Microsoft.OpenApi.Models;

namespace Rayson.WebApi.Utility.SwaggerExtension
{
    /// <summary>
    /// swagger文档扩展类
    /// </summary>
    public static class CustomSwaggerExtension
    {
        /// <summary>
        /// 配置swagger
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwaggerExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(option => {
                typeof(ApiSwaggerVersion).GetEnumNames().ToList().ForEach(version => {
                    option.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"Rayson.WabApi",
                        Version = version,
                        Description = $"Show Api Version_{version}"
                    });
                });
                var ApiXmlFile = Path.Combine(AppContext.BaseDirectory, "Rayson.WebApi.xml");
                //在文档中显示注释
                option.IncludeXmlComments(ApiXmlFile, true);
            });
        }

        /// <summary>
        /// 应用swagger
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerExtension(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                foreach (string version in typeof(ApiSwaggerVersion).GetEnumNames())
                {
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"Rayson.WebApi版本【{version}】");
                }
            });
        }
    }
}
