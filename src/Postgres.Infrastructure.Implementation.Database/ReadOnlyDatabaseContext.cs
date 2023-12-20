using Microsoft.EntityFrameworkCore;
using Postgres.Domain.Entities;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Infrastructure.Implementation.Database;

internal class ReadOnlyDatabaseContext(IDatabaseContext databaseContext) : IReadOnlyDatabaseContext
{
    public IQueryable<Blog> Blogs => databaseContext.Blogs.AsNoTracking();
}