namespace Postgres.Domain.Entities;

public class Blog
{
    /// <summary>
    /// Internal constructor for ORM
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal Blog()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public Blog(string name, Uri siteUri)
    {
        Name = name;
        SiteUri = siteUri;
    }

    public int Id { get; }
    public string Name { get; private set; }
    public Uri SiteUri { get; private set; }

    public ICollection<Post> Posts { get; } = new List<Post>();
}