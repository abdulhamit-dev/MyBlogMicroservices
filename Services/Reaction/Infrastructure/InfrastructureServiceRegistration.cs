using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Nucleo.Data.MongoDB;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection service)
    {
        service.AddScoped<ILikeRepository, LikeRepository>();
        service.AddMongoCollection<Like>("Likes");
        return service;
    }
}