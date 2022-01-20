using Microsoft.EntityFrameworkCore;
using Npgsql;
using Postgres.Api.Database;

namespace Postgres.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var dbContext = services.GetRequiredService<BloggingContext>();
        await dbContext.Database.MigrateAsync();

        await using var connection = (NpgsqlConnection)dbContext.Database.GetDbConnection();
        connection.Open();
        connection.ReloadTypes(); // https://www.npgsql.org/efcore/mapping/enum.html
    }
}