﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.Common;
using NewsChannel.Common.Attributes;
using NewsChannel.DomainClasses.Identity;
using NewsChannel.Service.Contracts;
using NewsChannel.ViewModel.RoleManager;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class RoleManagerController : BaseController
    {
        private readonly IApplicationRoleManager _roleManager;
        private readonly IMapper _mapper;
        private const string RoleNotFound = "نقش یافت نشد.";
        public RoleManagerController(IApplicationRoleManager roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _roleManager.CheckArgumentIsNull(nameof(_roleManager));

            _mapper = mapper;
            _mapper.CheckArgumentIsNull(nameof(_mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<JsonResult> GetRoles(string search, string order, int offset, int limit, string sort)
        {
            List<RolesViewModel> roles;
            int total = _roleManager.Roles.Count();

            if (string.IsNullOrWhiteSpace(search))
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "عنوان نقش")
            {
                if (order == "asc")
                    roles = await _roleManager.GetPaginateRolesAsync(offset, limit, true, search);
                else
                    roles = await _roleManager.GetPaginateRolesAsync(offset, limit, false, search);
            }

            else
                roles = await _roleManager.GetPaginateRolesAsync(offset, limit, null, search);

            if (search != "")
                total = roles.Count();

            return Json(new { total = total, rows = roles });
        }


        [HttpGet, AjaxOnly]
        public async Task<IActionResult> RenderRole(int? roleId)
        {
            var roleViewModel = new RolesViewModel();
            if (roleId != null)
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role != null)
                {
                    roleViewModel.Id = role.Id;
                    roleViewModel.Name = role.Name;
                    roleViewModel.Description = role.Description;
                }
                 
                else
                    ModelState.AddModelError(string.Empty, RoleNotFound);
            }
            return PartialView("_RenderRole", roleViewModel);
        }


        [HttpPost, AjaxOnly]
        public async Task<IActionResult> CreateOrUpdate(RolesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result;
                if (viewModel.Id != null)
                {
                    var role = await _roleManager.FindByIdAsync(viewModel.Id.ToString());
                    role.Name = viewModel.Name;
                    role.Description = viewModel.Description;
                    result = await _roleManager.UpdateAsync(role);
                }

                else
                {
                    Role roleModel = new Role(viewModel.Name)
                    {
                        Description = viewModel.Description
                    };
                    result = await _roleManager.CreateAsync(roleModel);
                    
                }

                if (result.Succeeded)
                    TempData["notification"] = OperationSuccess;
                else
                    ModelState.AddErrorsFromResult(result);
            }
            return PartialView("_RenderRole", viewModel);
        }


        [HttpGet, AjaxOnly]
        public async Task<IActionResult> Delete(int? roleId)
        {
            if (roleId== null)
                ModelState.AddModelError(string.Empty, RoleNotFound);
            else
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null)
                    ModelState.AddModelError(string.Empty, RoleNotFound);
                else
                {
                    RolesViewModel rolesViewModel=new RolesViewModel
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description,
                    };
                    return PartialView("_DeleteConfirmation", rolesViewModel);
                }
                   
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete"), AjaxOnly]
        public async Task<IActionResult> DeleteConfirmed(RolesViewModel viewModel)
        {
            var role = await _roleManager.FindByIdAsync(viewModel.Id.ToString());
            if (role == null)
                ModelState.AddModelError(string.Empty, RoleNotFound);
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    TempData["notification"] = DeleteSuccess;
                    return PartialView("_DeleteConfirmation", viewModel);
                }
                else
                    ModelState.AddErrorsFromResult(result);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("DeleteGroup"), AjaxOnly]
        public async Task<IActionResult> DeleteGroupConfirmed(string[] btSelectItem)
        {
            if (!btSelectItem.Any())
                ModelState.AddModelError(string.Empty, "هیچ نقشی برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var role = await _roleManager.FindByIdAsync(item);
                    var result = await _roleManager.DeleteAsync(role);
                }
                TempData["notification"] = "حذف گروهی نقش ها با موفقیت انجام شد..";
            }

            return PartialView("_DeleteGroup");
        }
    }
}