using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Notes.Infrastructure.Data;
using Notes.Infrastructure.Options;
using System.IO;
using FluentValidation;
using static Notes.NotesApi;
using static Notes.Infrastructure.Validations.NotesApi;

[assembly: FunctionsStartup(typeof(Notes.Startup))]
namespace Notes
{
    public class Startup : FunctionsStartup
    {
        private IConfiguration configuration;

        public Startup()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddValidatorsFromAssembly(typeof(Startup).Assembly)
                .AddScoped(typeof(IValidationScope<>), typeof(FunctionValidationScope<>))
                .AddSingleton(configuration)
                .AddDbContextPool<NotesDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(nameof(ConnectionStrings.SqlServer)), sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                    });
                });
        }
    }
}
