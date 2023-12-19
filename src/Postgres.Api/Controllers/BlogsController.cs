using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogsController(IDatabaseContext databaseContext) : ControllerBase
{
    [HttpGet("list-all")]
    public async Task<IActionResult> ListAll()
    {
        var blogs = await databaseContext.Blogs
            .Include(x => x.Posts)
            .ToListAsync();

        return Ok(blogs);
    }
}