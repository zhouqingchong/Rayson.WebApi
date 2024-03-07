using Rayson.BusinessInterface;
using Rayson.BusinessInterface.MapConfig;
using Rayson.BusinessService;
using Rayson.WebApi.Utility.InitDataBaseExtension;
using Rayson.WebApi.Utility.SwaggerExtension;

namespace Rayson.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            //��Ŀ�״�����Ҫ��ʼ�����ݿ�
            if (builder.Configuration["IsInitDB"] =="1")
            {
                builder.InitDataBase();
            }

            builder.AddInitSqlSugar();
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.AddSwaggerExtension();

            //Automapperӳ��
            builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
                
            //}

            app.UseSwaggerExtension();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
