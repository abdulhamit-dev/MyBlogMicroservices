using Application.Services.Repositories;
using Domain.Entities;
using MongoDB.Driver;
using Nucleo.Data.MongoDB;

namespace Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category,Guid>, ICategoryRepository
{
    public CategoryRepository(IMongoCollection<Category> collection) : base(collection)
    {
    }
}
