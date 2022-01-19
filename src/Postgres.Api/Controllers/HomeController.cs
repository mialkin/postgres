using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Api.Database;
using Postgres.Api.Enums;

namespace Postgres.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly BloggingContext _database;

    public HomeController(BloggingContext database)
    {
        _database = database;
    }

    [HttpGet]
    public async Task<IActionResult> InitializeWithTestData()
    {
        if (await _database.Blogs.AnyAsync()) return Ok();

        var blog = new Blog
        {
            Status = BlogStatus.Active,
            Url = "https://example.com",
            Posts = new List<Post>
            {
                new()
                {
                    Title = "Title 1",
                    Content = "Text 1"
                },
                new()
                {
                    Title = "Title 2",
                    Content = "Text 2"
                }
            }
        };

        _database.Blogs.Add(blog);
        await _database.SaveChangesAsync();

        var blog2 = new Blog
        {
            Status = BlogStatus.Inactive,
            Url = "https://example.com"
        };

        _database.Blogs.Add(blog2);

        await _database.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetData()
    {
        var blogs = await _database.Blogs
            .Include(x => x.Posts)
            .ToListAsync();

        return Ok(blogs);
    }
}