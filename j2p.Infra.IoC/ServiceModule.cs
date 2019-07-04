using j2p.Domain.Interfaces.Services;
using j2p.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace j2p.Infra.IoC
{
    public static class ServiceModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IServiceBase<object>, ServiceBase<object>>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IEventService, EventService > ();
        }
    }
}