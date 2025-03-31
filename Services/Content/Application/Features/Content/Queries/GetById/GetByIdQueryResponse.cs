namespace Application.Features.Content.Queries.GetById;

public class GetByIdQueryResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
    public User User { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
}

public class Comment
{
    public string Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public User User { get; set; }
}

public class Like
{
    public string Id { get; set; }
    public string ContentId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public User User { get; set; }
}

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
}