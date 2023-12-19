using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Api.Database;
using Postgres.Api.Database.Entities;

namespace Postgres.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController(BloggingContext database) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> InitializeWithTestData()
    {
        if (await database.Blogs.AnyAsync()) return Ok();

        var blog = new Blog(url: "https://example.com", status: BlogStatus.Active);

        blog.Posts = new List<Post>
        {
            new(title: "Title 1", content: "Text 1", blog),
            new(title: "Title 2", content: "Text 2", blog)
        };

        database.Blogs.Add(blog);
        await database.SaveChangesAsync();

        var blog2 = new Blog(url: "https://example.com", status: BlogStatus.Inactive);

        database.Blogs.Add(blog2);

        await database.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetData()
    {
        var blogs = await database.Blogs
            .Include(x => x.Posts)
            .ToListAsync();

        return Ok(blogs);
    }
}