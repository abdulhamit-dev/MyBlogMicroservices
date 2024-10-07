using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nucleo.DDD.Application.Pipelines.Validation;
namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        });
        
        return services;
    }
}
