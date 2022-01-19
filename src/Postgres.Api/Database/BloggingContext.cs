using Microsoft.EntityFrameworkCore;
using Npgsql;
using Postgres.Api.Enums;

namespace Postgres.Api.Database;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<BlogStatus>();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<BlogStatus>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseNpgsql("Host=localhost;Database=my_db;Username=my_user;Password=my_pw");
    }
}