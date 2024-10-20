using Application.Services.Repositories;
using Domain.Entities;
using MongoDB.Driver;
using Nucleo.Data.MongoDB;

namespace Infrastructure.Repositories;

public class LikeRepository:BaseRepository<Like,Guid>,ILikeRepository
{
    public LikeRepository(IMongoCollection<Like> collection) : base(collection)
    {
    }
    
}