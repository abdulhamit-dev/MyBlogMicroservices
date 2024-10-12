using MongoDB.Bson.Serialization.Attributes;

namespace Application.Features.Categories.Queries.GetList;

[BsonIgnoreExtraElements]
[BsonNoId]
public class GetListCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}