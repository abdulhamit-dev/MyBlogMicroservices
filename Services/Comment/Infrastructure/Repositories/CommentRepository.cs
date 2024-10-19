using Application.Services.Repositories;
using Domain.Entities;
using MongoDB.Driver;
using Nucleo.Data.MongoDB;

namespace Infrastructure.Repositories;

public class CommentRepository:BaseRepository<Comment,Guid>,ICommentRepository
{
    public CommentRepository(IMongoCollection<Comment> collection) : base(collection)
    {
    }

    public Task<Comment> GetByContentIdAsync(string id)
    {
        return _collection.Find(x => x.ContentId == id).FirstOrDefaultAsync();
    }
}