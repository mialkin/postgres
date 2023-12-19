namespace Postgres.Api.Database.Entities;

public class Post
{
    public Post(string title, string content, Blog blog)
    {
        Title = title;
        Content = content;
        Blog = blog;
    }

    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}