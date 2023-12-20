using Postgres.Domain.Entities;

namespace Postgres.Infrastructure.Interfaces.Database;

public interface IReadOnlyDatabaseContext
{
    IQueryable<Blog> Blogs { get; }
}