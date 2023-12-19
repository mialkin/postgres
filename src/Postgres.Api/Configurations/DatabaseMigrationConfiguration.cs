using Microsoft.EntityFrameworkCore;
using Postgres.Database;

namespace Postgres.Api.Configurations;

public static class DatabaseMigrationConfiguration
{
    public static async Task MigrateDatabaseAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var services = scope.ServiceProvider;

        var bloggingContext = services.GetRequiredService<BloggingContext>();
        
        // await bloggingContext.Database.EnsureCreatedAsync();
        await bloggingContext.Database.MigrateAsync();
    }
}