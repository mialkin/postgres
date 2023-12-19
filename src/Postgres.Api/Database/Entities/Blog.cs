namespace Postgres.Api.Database.Entities;

public class Blog
{
    public Blog(string url, BlogStatus status)
    {
        Url = url;
        Status = status;
    }

    public int BlogId { get; set; }
    public string Url { get; set; }
    public BlogStatus Status { get; set; }
    public List<Post>? Posts { get; set; }
}