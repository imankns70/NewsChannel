using Microsoft.Extensions.DependencyInjection;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DataLayer.UnitOfWork;
using NewsChannel.Service;
using NewsChannel.Service.Contracts;

namespace NewsChannel.IocConfig
{
    public static class AddCustomServicesExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IEmailSender, EmailSender>();
            return services;
        }
    }
}
