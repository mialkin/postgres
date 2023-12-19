using Microsoft.EntityFrameworkCore;

namespace Postgres.Api.Database.Extensions;

public static class DatabaseMigrationExtensions
{
    public static async Task MigrateDatabaseAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var services = scope.ServiceProvider;

        var bloggingContext = services.GetRequiredService<BloggingContext>();
        
        await bloggingContext.Database.EnsureCreatedAsync();
        await bloggingContext.Database.MigrateAsync();
    }
}