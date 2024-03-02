using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Idiomas.CRUD.Infraestructure.Context;
using Idiomas.CRUD.Infraestructure.DataBase;
using Idiomas.CRUD.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Idiomas.CRUD.Infraestructure
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdiomasContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            return services;
        }
    }
}
