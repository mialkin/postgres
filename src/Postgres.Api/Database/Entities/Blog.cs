namespace Postgres.Api.Database.Entities;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual Uri SiteUri { get; set; } = null!;

    public ICollection<Post> Posts { get; } = new List<Post>();
}