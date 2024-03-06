using Microsoft.OpenApi.Models;
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

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.AddSwaggerExtension();




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
