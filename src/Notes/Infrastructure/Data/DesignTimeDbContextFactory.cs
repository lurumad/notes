using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Notes.Infrastructure.Options;

namespace Notes.Infrastructure.Data
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<NotesDbContext>
    {
        public NotesDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json", optional: false)
                .Build();

            var builder = new DbContextOptionsBuilder<NotesDbContext>()
                .UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.SqlServer)), sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(typeof(DesignTimeContextFactory).Assembly.FullName);
                });


            return new NotesDbContext(builder.Options);
        }
    }
}
