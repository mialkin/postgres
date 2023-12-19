using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Infrastructure.Implementation.Database;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        // TODO Move to appsettings.Ide.json
        var connectionString = "User ID=postgres;Password=postgres;Host=localhost;Port=7020;Database=postgres";

        services.AddDbContext<IDatabaseContext, DatabaseContext>(builder =>
        {
            builder
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        return services;
    }
}