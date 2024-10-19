using Domain.Entities;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentResponse
{
    public Guid Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
}