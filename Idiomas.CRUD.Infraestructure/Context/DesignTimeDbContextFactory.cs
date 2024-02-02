
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Idiomas.CRUD.Infraestructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdiomasContext>
    {
        public IdiomasContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddUserSecrets<DesignTimeDbContextFactory>();
                     
            var config = configurationBuilder.Build();

            var builder = new DbContextOptionsBuilder<IdiomasContext>();
            var connectionString = config.GetConnectionString("Default");
            builder.UseSqlServer(connectionString);

            return new IdiomasContext(builder.Options);

        }
    }
}