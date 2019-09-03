using Microsoft.AspNetCore.Mvc;

namespace NewsChannel.Areas.Admin.Controllers
{

    [Area(AreaConstants.AdminArea)]
    public class BaseController : Controller
    {
        public IActionResult Notification()
        {
            return Content(TempData["notification"].ToString());
        }
    }
}