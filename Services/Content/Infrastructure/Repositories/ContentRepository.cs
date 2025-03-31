using Application.Services.Repositories;
using Domain.Entities;
using MongoDB.Driver;
using Nucleo.Data.MongoDB;

namespace Infrastructure.Repositories;

public class ContentRepository: BaseRepository<Content,Guid>, IContentRepository
{
    public ContentRepository(IMongoCollection<Content> collection) : base(collection)
    {
    }
}