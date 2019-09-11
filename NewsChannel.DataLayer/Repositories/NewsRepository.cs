using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.ViewModel.News;

namespace NewsChannel.DataLayer.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext _context;
        
        public NewsRepository(NewsDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));

            
        }


        public async Task<List<NewsViewModel>> GetPaginateNewsAsync(int offset, int limit, bool? titleSortAsc, bool? visitSortAsc, bool? likeSortAsc, bool? dislikeSortAsc, bool? publishDateTimeSortAsc, string searchText)
        {
            string NameOfCategories = "";
            string NameOfTags = "";
            List<NewsViewModel> newsViewModel = new List<NewsViewModel>();

            var newsGroup = await (from n in _context.News.Include(v => v.Visits).Include(l => l.Likes).Include(u=>u.User)
                                   join e in _context.NewsCategories on n.Id equals e.NewsId into bc
                                   from bct in bc.DefaultIfEmpty()
                                   join c in _context.Categories on bct.CategoryId equals c.Id into cg
                                   from cog in cg.DefaultIfEmpty()
                                   join a in _context.NewsTags on n.Id equals a.NewsId into ac
                                   from act in ac.DefaultIfEmpty()
                                   join t in _context.Tags on act.TagId equals t.Id into tg
                                   from tog in tg.DefaultIfEmpty()
                                   where (n.Title.Contains(searchText))
                                   select (new
                                   {
                                       n.Id,
                                       n.Title,
                                       ShortTitle = n.Title.Length > 60 ? n.Title.Substring(0, 60) + "..." : n.Title,
                                       n.Url,
                                       n.Description,
                                       NumberOfVisit = n.Visits.Select(v => v.NumberOfVisit).Sum(),
                                       NumberOfLike = n.Likes.Where(l => l.IsLike == true).Count(),
                                       NumberOfDisLike = n.Likes.Where(l => l.IsLike == false).Count(),
                                       CategoryName = cog != null ? cog.CategoryName : "",
                                       TagName= tog!=null ? tog.TagName :"",
                                       AuthorName=n.User.FirstName+" "+ n.User.LastName,
                                       n.IsPublish,
                                       NewsType = n.IsInternal == true ? "داخلی" : "خارجی",
                                       PublishDateTime=n.PublishDateTime==null? new DateTime(01,01,01):n.PublishDateTime,
                                       PersianPublishDateTime = n.PublishDateTime==null?"-": n.PublishDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت hh:mm:ss"),
                                   })).GroupBy(b => b.Id).Select(g => new { NewsId = g.Key, NewsGroup = g }).Skip(offset).Take(limit).AsNoTracking().ToListAsync();

            foreach (var item in newsGroup)
            {
                NameOfCategories = "";
                NameOfTags = "";
                foreach (var a in item.NewsGroup.Select(a => a.CategoryName).Distinct())
                {
                    if (NameOfCategories == "")
                        NameOfCategories = a;
                    else
                        NameOfCategories = NameOfCategories + " - " + a;
                }

                foreach (var a in item.NewsGroup.Select(a => a.TagName).Distinct())
                {
                    if (NameOfTags == "")
                        NameOfTags = a;
                    else
                        NameOfTags = NameOfTags + " - " + a;
                }

                NewsViewModel news = new NewsViewModel()
                {
                    NewsId = item.NewsId,
                    Title = item.NewsGroup.First().Title,
                    ShortTitle = item.NewsGroup.First().ShortTitle,
                    Url = item.NewsGroup.First().Url,
                    Description = item.NewsGroup.First().Description,
                    NumberOfVisit = item.NewsGroup.First().NumberOfVisit,
                    NumberOfDisLike = item.NewsGroup.First().NumberOfDisLike,
                    NumberOfLike = item.NewsGroup.First().NumberOfLike,
                    PersianPublishDate = item.NewsGroup.First().PersianPublishDateTime,
                    NewsType = item.NewsGroup.First().NewsType,
                    Status = item.NewsGroup.First().IsPublish==false?"پیش نویس": (item.NewsGroup.First().PublishDateTime > DateTime.Now ? "انتشار در آینده" : "منتشر شده"),
                    NameOfCategories = NameOfCategories,
                    NameOfTags = NameOfTags,
                    AuthorName = item.NewsGroup.First().AuthorName,
                };
                newsViewModel.Add(news);
            }

            if (titleSortAsc != null)
                newsViewModel = newsViewModel.OrderBy(c => (titleSortAsc == true) ? c.Title : "")
                                     .ThenByDescending(c => (titleSortAsc == false) ? c.Title : "").ToList();

            else if (visitSortAsc != null)
                newsViewModel = newsViewModel.OrderBy(c => (visitSortAsc == true) ? c.NumberOfVisit : 0)
                                   .ThenByDescending(c => (visitSortAsc == false) ? c.NumberOfVisit : 0).ToList();

            else if (likeSortAsc != null)
                newsViewModel = newsViewModel.OrderBy(c => (likeSortAsc == true) ? c.NumberOfLike : 0)
                                   .ThenByDescending(c => (likeSortAsc == false) ? c.NumberOfLike : 0).ToList();

            else if (dislikeSortAsc != null)
                newsViewModel = newsViewModel.OrderBy(c => (dislikeSortAsc == true) ? c.NumberOfDisLike : 0)
                                   .ThenByDescending(c => (dislikeSortAsc == false) ? c.NumberOfDisLike : 0).ToList();

            else if (publishDateTimeSortAsc != null)
                newsViewModel = newsViewModel.OrderBy(c => (publishDateTimeSortAsc == true) ? c.PersianPublishDate : "")
                                   .ThenByDescending(c => (publishDateTimeSortAsc == false) ? c.PersianPublishDate : "").ToList();

            foreach (var item in newsViewModel)
                item.Row = ++offset;

            return newsViewModel;

        }

        public string CheckNewsFileName(string fileName)
        {
            string fileExtension = Path.GetExtension(fileName);
            int fileNameCount = _context.News.Count(f => f.ImageName == fileName);
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
