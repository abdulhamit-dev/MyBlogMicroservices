using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Services.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public Task AddAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<Category> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRangeAsync(IEnumerable<Category> entities)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category entity)
    {
        throw new NotImplementedException();
    }
}
