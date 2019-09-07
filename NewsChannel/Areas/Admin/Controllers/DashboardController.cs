using Microsoft.AspNetCore.Mvc;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}