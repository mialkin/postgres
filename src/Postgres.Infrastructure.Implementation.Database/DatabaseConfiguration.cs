using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Infrastructure.Implementation.Database;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(
        this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        var postgresSettings =
            builderConfiguration.GetRequiredSection(key: nameof(PostgresSettings)).Get<PostgresSettings>();

        if (string.IsNullOrWhiteSpace(postgresSettings?.ConnectionString))
        {
            throw new InvalidOperationException("PostgreSQL connection string is not set");
        }

        services.AddDbContext<IDatabaseContext, DatabaseContext>(builder =>
        {
            builder
                .UseNpgsql(postgresSettings.ConnectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IReadOnlyDatabaseContext, ReadOnlyDatabaseContext>();

        return services;
    }
}
