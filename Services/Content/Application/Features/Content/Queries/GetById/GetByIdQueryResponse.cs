namespace Application.Features.Content.Queries.GetById;

public class GetByIdQueryResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string UserId { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
}
