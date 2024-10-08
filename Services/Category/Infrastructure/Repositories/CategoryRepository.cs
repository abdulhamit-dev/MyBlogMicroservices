using System;
using Domain.Entities;
using MongoDB.Driver;
using Nucleo.Data.MongoDB;


namespace Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>
{
    public CategoryRepository(IMongoCollection<Category> collection) : base(collection)
    {
    }
}
