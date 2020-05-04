using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Notes.Infrastructure.Authentication;
using Notes.Infrastructure.Data;
using Notes.Infrastructure.Options;
using System.IO;

[assembly: FunctionsStartup(typeof(Notes.Startup))]
namespace Notes
{
    public class Startup : FunctionsStartup
    {
        private IConfiguration configuration;

        public Startup()
        {
            IdentityModelEventSource.ShowPII = true;

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddLogging()
                .AddHttpClient()
                .AddSingleton(configuration)
                .Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)))
                .AddScoped(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value)
                .AddValidatorsFromAssembly(typeof(Startup).Assembly)
                .AddScoped<IAccessTokenValidator, JwtAccessTokenValidator>()
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
