using Domain.Entities;

namespace Application.Features.Comments.Queries.GetAllByContentId;

public class GetAllByContentIdResponse
{
    public Guid Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}