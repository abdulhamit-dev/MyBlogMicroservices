
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nucleo.Data;

namespace Domain.Entities;

[BsonIgnoreExtraElements]
public class Category : IEntityBase<Guid>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "System";
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = "System";
    public bool IsDeleted { get; set; }
}
