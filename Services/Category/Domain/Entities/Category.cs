using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nucleo.Data;

namespace Domain.Entities;

public class Category:IEntityBase<Guid>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy {get; set; }
    public bool IsDeleted { get; set; }
}
