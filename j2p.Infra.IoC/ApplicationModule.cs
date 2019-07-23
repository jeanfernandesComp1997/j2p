using j2p.Application;
using j2p.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace j2p.Infra.IoC
{
    public static class ApplicationModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IAppServiceBase<object>, AppServiceBase<object>>();
            services.AddTransient<IPlayerAppService, PlayerAppService>();
            services.AddTransient<IEventAppService, EventAppService>();
            services.AddTransient<ILocalAppService, LocalAppService>();
            services.AddTransient<IOwnerAppService, OwnerAppService>();
        }
    }
}