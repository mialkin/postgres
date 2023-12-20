using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Api.Blogs.Dtos;
using Postgres.Domain.Entities;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Api.Blogs;

[ApiController]
[Route("[controller]")]
public class BlogsController(
    IReadOnlyDatabaseContext readOnlyDatabaseContext,
    IDatabaseContext databaseContext) : ControllerBase
{
    [HttpGet("list-all")]
    public async Task<IActionResult> ListAll()
    {
        var blogs = await readOnlyDatabaseContext.Blogs
            .Include(x => x.Posts)
            .ToListAsync();

        return Ok(blogs);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateBlogDto dto, CancellationToken cancellationToken)
    {
        databaseContext.Blogs.Add(new Blog(dto.Name, dto.SiteUri));
        await databaseContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}