using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Video;

namespace NewsChannel.ViewComponents
{
    public class RandomVideosList : ViewComponent
    {

        private readonly IUnitOfWork _uw;
        public RandomVideosList(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var videoList = new List<VideoViewModel>();
            for (int i = 0; i < number; i++)
            {
                var randomRow = CustomMethods.RandomNumber(1, _uw.BaseRepository<Video>().CountEntities()+1);
                var video = await _uw._Context.Videos.Select(n => new VideoViewModel { Title = n.Title, Url = n.Url, VideoId = n.VideoId, Poster = n.Poster }).Skip(randomRow - 1).Take(1).FirstOrDefaultAsync();
                videoList.Add(video);
            }

            return View(videoList);
        }
    }
}
