using Microsoft.AspNetCore.Mvc;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
   
        public IActionResult Index()
        {
            return View();
        }
    }
}