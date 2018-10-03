using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infra
{
    class EventProjectDbContextFactory : IDesignTimeDbContextFactory<EventProjectDbContext>
    {

        EventProjectDbContext IDesignTimeDbContextFactory<EventProjectDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EventProjectDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new EventProjectDbContext(builder.Options);
        }
    }
}