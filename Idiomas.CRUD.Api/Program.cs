using Idiomas.CRUD.Application;
using Idiomas.CRUD.Infraestructure;

namespace Idiomas.CRUD.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            var conectionstr = builder.Configuration.GetConnectionString("Default") ??
                                     throw new Exception("DefaultConnection configuration is missing");
            builder.Services
                .RegisterApplication(builder.Configuration)
                .RegisterRepository(builder.Configuration.GetConnectionString("Default"));



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();
            

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }

}

