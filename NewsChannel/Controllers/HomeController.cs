using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.ViewModel.Home;
using NewsChannel.ViewModel.News;

namespace NewsChannel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uw;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _uw = unitOfWork;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            List<NewsViewModel> news = await _uw.NewsRepository.GetPaginateNewsAsync(0, 10, null, null, null, null, false, "", true);
            HomePageViewModel homePageViewModel = new HomePageViewModel(news);
            return View(homePageViewModel);
        }
    }
}