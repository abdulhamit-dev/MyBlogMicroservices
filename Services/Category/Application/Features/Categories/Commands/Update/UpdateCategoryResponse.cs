namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
}