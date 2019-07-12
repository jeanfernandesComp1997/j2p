using j2p.Domain.Interfaces.Repositories;
using j2p.Infra.Data.NHibernate.Repositories;
using j2p.Infra.Data.NHibernate.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace j2p.Infra.IoC
{
    public static class RepositoryModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IUoWRepository, UnitOfWork>();
            services.AddTransient<IBaseRepository<object>, RepositoryBase<object>>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
        }
    }
}