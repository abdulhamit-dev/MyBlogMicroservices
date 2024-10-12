using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Nucleo.Data.MongoDB;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection service)
    {
            
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddMongoCollection<Category>("Categories");
        return service;
    }
}