using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Database;

namespace Postgres.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController(BloggingContext database) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetData()
    {
        var blogs = await database.Blogs
            .Include(x => x.Posts)
            .ToListAsync();

        return Ok(blogs);
    }
}