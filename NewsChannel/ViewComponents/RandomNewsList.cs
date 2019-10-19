using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.ViewModel.News;

namespace NewsChannel.ViewComponents
{
    public class RandomNewsList : ViewComponent
    {
        private readonly IUnitOfWork _uw;
        public RandomNewsList(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var newsList = new List<NewsViewModel>();
            for (int i=0;i<number;i++)
            {
                var randomRow = CustomMethods.RandomNumber(1, _uw.NewsRepository.CountNewsPublished()+1);
                var news = await _uw._Context.News.Where(n => n.IsPublish == true && n.PublishDateTime <= DateTime.Now).Select(n => new NewsViewModel { Title = n.Title, Url = n.Url, NewsId = n.Id, ImageName = n.ImageName }).Skip(randomRow-1).Take(1).FirstOrDefaultAsync();
                newsList.Add(news);
            }
           
            return View(newsList);
        }
    }
}
