using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.ViewModel.Video;

namespace NewsChannel.DataLayer.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly NewsDbContext _context;
        public VideoRepository(NewsDbContext context)
        {
            _context = context;
        }


        public async Task<List<VideoViewModel>> GetPaginateVideosAsync(int offset, int limit, bool? titleSortAsc, bool? publishDateTimeSortAsc, string searchText)
        {
            List<VideoViewModel> videos= await _context.Videos.Where(c => c.Title.Contains(searchText))
                                    .Select(c => new VideoViewModel
                {
                    VideoId = c.VideoId, Title = c.Title, Url = c.Url, Poster=c.Poster,PersianPublishDateTime=c.PublishDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت HH:mm:ss")
                }).Skip(offset).Take(limit).AsNoTracking().ToListAsync();

            if (titleSortAsc != null)
            {
                videos = videos.OrderBy(c => (titleSortAsc == true) ? c.Title : "")
                                    .ThenByDescending(c => (titleSortAsc == false) ? c.Title : "").ToList();
            }

            else if (publishDateTimeSortAsc != null)
            {
                videos = videos.OrderBy(c => (publishDateTimeSortAsc == true) ? c.PersianPublishDateTime : "")
                                   .ThenByDescending(c => (publishDateTimeSortAsc == false) ? c.PersianPublishDateTime : "").ToList();
            }

            foreach (var item in videos)
                item.Row = ++offset;

            return videos;
        }

        public string CheckVideoFileName(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            int fileNameCount = _context.Videos.Count(f => f.Poster == fileName);
            int j = 1;
            while (fileNameCount != 0)
            {
                fileName = fileName.Replace(fileExtension, "") + j + fileExtension;
                fileNameCount = _context.Videos.Count(f => f.Poster == fileName);
                j++;
            }

            return fileName;
        }
    }
}
