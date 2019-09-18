using Microsoft.AspNetCore.Mvc;

namespace NewsChannel.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}