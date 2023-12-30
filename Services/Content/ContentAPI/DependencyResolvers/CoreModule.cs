
using ContentAPI.IoC;
using ContentAPI.Services;

namespace ContentAPI.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILogService,LogService>();
            services.AddSingleton<ITextSearchService,TextSearchService>();
        }
    }
}
