using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.ViewModel.News;

namespace NewsChannel.ViewComponents
{
    public class LatestNewsTitleList : ViewComponent
    {
        private readonly IUnitOfWork _uw;
        public LatestNewsTitleList(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var newsTitles = await _uw._Context.News.Where(n => n.IsPublish && n.PublishDateTime <= DateTime.Now).OrderByDescending(n => n.PublishDateTime).Select(n => new NewsViewModel {Title=n.Title,Url=n.Url,NewsId=n.Id}).Take(10).ToListAsync();
            return View(newsTitles);
        }
    }
}
