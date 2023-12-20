using Microsoft.EntityFrameworkCore;
using Postgres.Domain.Entities;
using Postgres.Infrastructure.Implementation.Database.EntityTypeConfigurations;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Infrastructure.Implementation.Database;

public sealed class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
    }
}