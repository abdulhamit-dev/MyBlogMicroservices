
using ContentAPI.IoC;
using ContentAPI.Models.Settings;
using ContentAPI.Services;
using Microsoft.Extensions.Options;

namespace ContentAPI.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHostedService<ContentBackgroundService>();
            services.AddHostedService<ReactionBackgroundService>();
            services.AddSingleton<IContentService, ContentService>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<ITextSearchService, TextSearchService>();
            services.AddSingleton<IDatabaseSettings>(sp =>
                {
                    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                });
        }
    }
}
