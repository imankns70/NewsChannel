﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using NewsChannel.Service.Contracts;

namespace NewsChannel.IocConfig
{
    public class DynamicPermissionRequirement : IAuthorizationRequirement
    {
    }

    public class DynamicPermissionsAuthorizationHandler : AuthorizationHandler<DynamicPermissionRequirement>
    {
        private readonly ISecurityTrimmingService _securityTrimmingService;

        public DynamicPermissionsAuthorizationHandler(ISecurityTrimmingService securityTrimmingService)
        {
            _securityTrimmingService = securityTrimmingService;
        }

        protected override Task HandleRequirementAsync(
             AuthorizationHandlerContext context,
             DynamicPermissionRequirement requirement)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            if (mvcContext == null)
            {
                return Task.CompletedTask;
            }

            var actionDescriptor = mvcContext.ActionDescriptor;

            actionDescriptor.RouteValues.TryGetValue("area", out var areaName);
            var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;

            actionDescriptor.RouteValues.TryGetValue("controller", out var controllerName);
            var controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;

            actionDescriptor.RouteValues.TryGetValue("action", out var actionName);
            var action = string.IsNullOrWhiteSpace(actionName) ? string.Empty : actionName;

            if (_securityTrimmingService.CanCurrentUserAccess(area, controller, action))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
