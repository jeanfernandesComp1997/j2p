using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using j2p.Domain.Services;
using j2p.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace j2p.Infra.IoC
{
    public static class ServiceModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IServiceBase<object>, ServiceBase<object>>();
            services.AddTransient<IPlayerService, PlayerService>();
        }
    }
}