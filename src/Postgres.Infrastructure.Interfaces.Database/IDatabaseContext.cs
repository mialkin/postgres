using Microsoft.EntityFrameworkCore;
using Postgres.Domain.Entities;

namespace Postgres.Infrastructure.Interfaces.Database;

public interface IDatabaseContext
{
    public DbSet<Blog> Blogs { get; }
    public DbSet<Post> Posts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
