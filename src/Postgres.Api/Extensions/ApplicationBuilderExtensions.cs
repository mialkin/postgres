using Microsoft.EntityFrameworkCore;
using Postgres.Api.Database;

namespace Postgres.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task MigrateDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var dbContext = services.GetRequiredService<BloggingContext>();
        
        await dbContext.Database.EnsureCreatedAsync();
        await dbContext.Database.MigrateAsync();
    }
}