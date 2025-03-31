using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nucleo.Data;

namespace Domain.Entities;
[BsonIgnoreExtraElements]
public class Content: IEntityBase<Guid>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }=true;
    public string CategoryId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = "System";
    public bool IsDeleted { get; set; }
}