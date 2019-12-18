using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using NewsChannel.Service;
using NewsChannel.Service.Contracts;
using NewsChannel.ViewModel.DynamicAccess;

namespace NewsChannel.IocConfig
{
    public static class AddDynamicPermissionExtensions
    {
        public static IServiceCollection AddDynamicPermission(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, DynamicPermissionsAuthorizationHandler>();
            services.AddSingleton<IMvcActionsDiscoveryService, MvcActionsDiscoveryService>();
            services.AddSingleton<ISecurityTrimmingService, SecurityTrimmingService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(ConstantPolicies.DynamicPermission, policy => policy.Requirements.Add(new DynamicPermissionRequirement()));
            });

            return services;
        }
    }
}
