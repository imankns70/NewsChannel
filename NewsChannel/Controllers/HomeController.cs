using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Index(string duration, string TypeOfNews)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax && TypeOfNews == "MostViewedNews")
                return PartialView("_MostViewedNews", await _uw.NewsRepository.MostViewedNews(0, 3, duration));

            if (isAjax && TypeOfNews == "MostTalkNews")
                return PartialView("_MostTalkNews", await _uw.NewsRepository.MostTalkNews(0, 5, duration));
            List<NewsViewModel> news = _uw.NewsRepository.GetPaginateNews(0, 10, item => "", item => item.First().PersianPublishDate, "", true,null);
            List<NewsViewModel> mostViewedNews = await _uw.NewsRepository.MostViewedNews(0, 3, "day");
            List<NewsViewModel> mostTalkNews = await _uw.NewsRepository.MostTalkNews(0, 5, "day");
            List<NewsViewModel> mostPopulerNews = await _uw.NewsRepository.MostPopularNews(0, 5);
            List<NewsViewModel> internalNews =  _uw.NewsRepository.GetPaginateNews(0, 10, item => "", item => item.First().PersianPublishDate,"",true,true);
            List<NewsViewModel> foreignNews =  _uw.NewsRepository.GetPaginateNews(0, 10, item => "", item => item.First().PersianPublishDate,"",true,false);
            var homePageViewModel = new HomePageViewModel(news, mostViewedNews, mostTalkNews, mostPopulerNews,internalNews,foreignNews);
            return View(homePageViewModel);


        }
    }
}