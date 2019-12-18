using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.Service.Contracts;
using NewsChannel.ViewModel.DynamicAccess;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class DynamicAccessController : BaseController
    {
        public readonly IApplicationUserManager _userManager;
        public readonly IMvcActionsDiscoveryService _mvcActionsDiscovery;
        public DynamicAccessController(IApplicationUserManager userManager, IMvcActionsDiscoveryService mvcActionsDiscovery)
        {
            _userManager = userManager;
            _mvcActionsDiscovery = mvcActionsDiscovery;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int userId)
        {
            if (userId == 0)
                return NotFound();


            var user = await _userManager.FindClaimsInUser(userId);
            if (user == null)
                return NotFound();

            var securedControllerActions = _mvcActionsDiscovery.GetAllSecuredControllerActionsWithPolicy(ConstantPolicies.DynamicPermission);
            return View(new DynamicAccessIndexViewModel
            {
                UserIncludeUserClaims = user,
                SecuredControllerActions = securedControllerActions,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(DynamicAccessIndexViewModel viewModel)
        {
            var Result = await _userManager.AddOrUpdateClaimsAsync(viewModel.UserId, ConstantPolicies.DynamicPermissionClaimType, viewModel.ActionIds.Split(","));
            if (!Result.Succeeded)
                ModelState.AddModelError(string.Empty, "در حین انجام عملیات خطایی رخ داده است.");

            return RedirectToAction("Index", new { userId = viewModel.UserId });
        }
    }
}