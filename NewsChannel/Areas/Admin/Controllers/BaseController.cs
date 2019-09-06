﻿using Microsoft.AspNetCore.Mvc;
using NewsChannel.Common.Attributes;

namespace NewsChannel.Areas.Admin.Controllers
{

    [Area(AreaConstants.AdminArea)]
    public class BaseController : Controller
    {
        public const string InsertSuccess = "درج اطلاعات با موفقیت انجام شد.";
        public const string EditSuccess = "ویرایش اطلاعات با موفقیت انجام شد.";
        public const string DeleteSuccess = "حذف اطلاعات با موفقیت انجام شد.";
        public const string OperationSuccess = "عملیات با موفقیت انجام شد.";
        public IActionResult Notification()
        {
            return Content(TempData["notification"].ToString());
        }
        [HttpGet, AjaxOnly]
        public IActionResult DeleteGroup()
        {
            return PartialView("_DeleteGroup");
        }
    }
}