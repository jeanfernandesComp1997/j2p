﻿using j2p.Application;
using j2p.Application.Interfaces;
using j2p.Domain.Interfaces.Repositories;
using j2p.Domain.Interfaces.Services;
using j2p.Domain.Services;
using j2p.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace j2p.Infra.IoC
{
    public static class ApplicationModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IAppServiceBase<object>, AppServiceBase<object>>();
            services.AddTransient<IPlayerAppService, PlayerAppService>();
        }
    }
}