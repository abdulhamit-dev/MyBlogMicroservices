using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nucleo.DDD.Application.Pipelines.Caching;
using Nucleo.DDD.Application.Pipelines.Logging;
using Nucleo.DDD.Application.Pipelines.Validation;
using Nucleo.DDD.CrossCuttingConcerns.Serilog;
using Nucleo.DDD.CrossCuttingConcerns.Serilog.Logger;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddSingleton<LoggerServiceBase, MongoDbLogger>();
        
        return services;
    }
}
