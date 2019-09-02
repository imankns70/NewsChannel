﻿using Microsoft.Extensions.DependencyInjection;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DataLayer.UnitOfWork;

namespace NewsChannel.IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
