namespace Postgres.Domain.Entities;

public class Blog
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Uri SiteUri { get; set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}