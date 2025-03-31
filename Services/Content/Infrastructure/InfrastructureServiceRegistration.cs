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
        service.AddScoped<IContentRepository, ContentRepository>();
        service.AddMongoCollection<Content>("Contents");
        return service;
    }
}