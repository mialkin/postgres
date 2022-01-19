using Microsoft.AspNetCore.Mvc;
using Postgres.Api.Database;

namespace Postgres.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly BloggingContext _database;

    public HomeController(BloggingContext database)
    {
        _database = database;
    }

    [HttpGet(Name = "GetData")]
    public IActionResult GetData()
    {
        var blogs = _database.Blogs.ToList();
        return Ok(blogs);
    }
}