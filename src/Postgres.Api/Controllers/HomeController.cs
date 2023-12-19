using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Infrastructure.Interfaces.Database;

namespace Postgres.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController(IDatabaseContext databaseContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetData()
    {
        var blogs = await databaseContext.Blogs
            .Include(x => x.Posts)
            .ToListAsync();

        return Ok(blogs);
    }
}