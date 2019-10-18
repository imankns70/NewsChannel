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


        public List<NewsViewModel> GetPaginateNews(int offset, int limit, Func<IGrouping<int?, NewsViewModel>, object> orderByAscFunc, Func<IGrouping<int?, NewsViewModel>, object> orderByDescFunc, string searchText, bool? isPublish, bool? isInternal)
        {
            string NameOfCategories = "";
            string NameOfTags = "";
            List<NewsViewModel> newsViewModel = new List<NewsViewModel>();


            var newsGroup = (from n in _context.News.Include(v => v.Visits).Include(l => l.Likes).Include(u => u.User).Include(c => c.Comments)
                             join e in _context.NewsCategories on n.Id equals e.NewsId into bc
                             from bct in bc.DefaultIfEmpty()
                             join c in _context.Categories on bct.CategoryId equals c.Id into cg
                             from cog in cg.DefaultIfEmpty()
                             join a in _context.NewsTags on n.Id equals a.NewsId into ac
                             from act in ac.DefaultIfEmpty()
                             join t in _context.Tags on act.TagId equals t.Id into tg
                             from tog in tg.DefaultIfEmpty()
                             where (n.Title.Contains(searchText) && isPublish == null ? (n.IsPublish == true || n.IsPublish == false) : (isPublish == true ? n.IsPublish == true && n.PublishDateTime <= DateTime.Now : n.IsPublish == false)&& isInternal==null? n.IsInternal==true|| n.IsInternal==false : (isInternal==true ? n.IsInternal : n.IsInternal==false))
                             select (new NewsViewModel
                             {
                                 NewsId = n.Id,
                                 Title = n.Title,
                                 Abstract = n.Abstract,
                                 ShortTitle = n.Title.Length > 30 ? n.Title.Substring(0, 30) + "..." : n.Title,
                                 Url = n.Url,
                                 ImageName = n.ImageName,
                                 Description = n.Description,
                                 NumberOfVisit = n.Visits.Select(v => v.NumberOfVisit).Sum(),
                                 NumberOfLike = n.Likes.Count(l => l.IsLike == true),
                                 NumberOfDisLike = n.Likes.Count(l => l.IsLike == false),
                                 NumberOfComment = n.Comments.Count(),
                                 NameOfCategories = cog != null ? cog.CategoryName : "",
                                 NameOfTags = tog != null ? tog.TagName : "",
                                 AuthorName = n.User.FirstName + " " + n.User.LastName,
                                 IsPublish = n.IsPublish,
                                 NewsType = n.IsInternal == true ? "داخلی" : "خارجی",
                                 PublishDateTime = n.PublishDateTime ?? new DateTime(01, 01, 01),
                                 PersianPublishDate = n.PublishDateTime == null ? "-" : n.PublishDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت HH:mm:ss"),
                             })).GroupBy(b => b.NewsId).AsEnumerable().OrderBy(orderByAscFunc).ThenByDescending(orderByDescFunc).Select(g => new { NewsId = g.Key, NewsGroup = g }).Skip(offset).Take(limit).ToList();

            foreach (var item in newsGroup)
            {
                NameOfCategories = "";
                NameOfTags = "";
                foreach (var a in item.NewsGroup.Select(a => a.NameOfCategories).Distinct())
                {
                    if (NameOfCategories == "")
                        NameOfCategories = a;
                    else
                        NameOfCategories = NameOfCategories + " - " + a;
                }

                foreach (var a in item.NewsGroup.Select(a => a.NameOfTags).Distinct())
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
                    Abstract = item.NewsGroup.First().Abstract,
                    Url = item.NewsGroup.First().Url,
                    Description = item.NewsGroup.First().Description,
                    NumberOfVisit = item.NewsGroup.First().NumberOfVisit,
                    NumberOfDisLike = item.NewsGroup.First().NumberOfDisLike,
                    NumberOfLike = item.NewsGroup.First().NumberOfLike,
                    PersianPublishDate = item.NewsGroup.First().PersianPublishDate,
                    NewsType = item.NewsGroup.First().NewsType,
                    Status = item.NewsGroup.First().IsPublish == false ? "پیش نویس" : (item.NewsGroup.First().PublishDateTime > DateTime.Now ? "انتشار در آینده" : "منتشر شده"),
                    NameOfCategories = NameOfCategories,
                    NameOfTags = NameOfTags,
                    ImageName = item.NewsGroup.First().ImageName,
                    AuthorName = item.NewsGroup.First().AuthorName,
                    NumberOfComment = item.NewsGroup.First().NumberOfComment,
                    PublishDateTime = item.NewsGroup.First().PublishDateTime,
                };
                newsViewModel.Add(news);
            }

             

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
        public async Task<List<NewsViewModel>> MostViewedNews(int offset, int limit, string duration)
        {
            List<NewsViewModel> newsViewModel = new List<NewsViewModel>();
            DateTime startMiladiDate;
            DateTime endMiladiDate = DateTime.Now;

            if (duration == "week")
            {
                int numOfWeek = ConvertDateTime.ConvertMiladiToShamsi(DateTime.Now, "dddd").GetNumOfWeek();
                startMiladiDate = DateTime.Now.AddDays((-1) * numOfWeek).Date + new TimeSpan(0, 0, 0);
            }

            else if (duration == "day")
                startMiladiDate = DateTime.Now.Date + new TimeSpan(0, 0, 0);

            else
            {
                string dayOfMonth = ConvertDateTime.ConvertMiladiToShamsi(DateTime.Now, "dd").Fa2En();
                startMiladiDate = DateTime.Now.AddDays((-1) * (int.Parse(dayOfMonth) - 1)).Date + new TimeSpan(0, 0, 0);
            }

            var newsGroup = await (from n in _context.News.Include(v => v.Visits).Include(l => l.Likes).Include(c => c.Comments)
                                   join e in _context.NewsCategories on n.Id equals e.NewsId into bc
                                   from bct in bc.DefaultIfEmpty()
                                   join c in _context.Categories on bct.CategoryId equals c.Id into cg
                                   from cog in cg.DefaultIfEmpty()
                                   where (n.PublishDateTime <= endMiladiDate && startMiladiDate <= n.PublishDateTime)
                                   select (new
                                   {
                                       n.Id,
                                       ShortTitle = n.Title.Length > 60 ? n.Title.Substring(0, 60) + "..." : n.Title,
                                       n.Url,
                                       NumberOfVisit = n.Visits.Select(v => v.NumberOfVisit).Sum(),
                                       NumberOfLike = n.Likes.Count(l => l.IsLike),
                                       NumberOfDisLike = n.Likes.Count(l => l.IsLike == false),
                                       NumberOfComments = n.Comments.Count(),
                                       n.ImageName,
                                       CategoryName = cog != null ? cog.CategoryName : "",
                                       PublishDateTime = n.PublishDateTime ?? new DateTime(01, 01, 01),
                                   })).GroupBy(b => b.Id).Select(g => new { NewsId = g.Key, NewsGroup = g }).OrderByDescending(g => g.NewsGroup.First().NumberOfVisit).Skip(offset).Take(limit).AsNoTracking().ToListAsync();

            foreach (var item in newsGroup)
            {
                var nameOfCategories = "";
                foreach (var a in item.NewsGroup.Select(a => a.CategoryName).Distinct())
                {
                    if (nameOfCategories == "")
                        nameOfCategories = a;
                    else
                        nameOfCategories = nameOfCategories + " - " + a;
                }

                NewsViewModel news = new NewsViewModel()
                {
                    NewsId = item.NewsId,
                    ShortTitle = item.NewsGroup.First().ShortTitle,
                    Url = item.NewsGroup.First().Url,
                    NumberOfVisit = item.NewsGroup.First().NumberOfVisit,
                    NumberOfDisLike = item.NewsGroup.First().NumberOfDisLike,
                    NumberOfLike = item.NewsGroup.First().NumberOfLike,
                    NameOfCategories = nameOfCategories,
                    PublishDateTime = item.NewsGroup.First().PublishDateTime,
                    ImageName = item.NewsGroup.First().ImageName,
                };
                newsViewModel.Add(news);
            }

            return newsViewModel;
        }

        public async Task<List<NewsViewModel>> MostTalkNews(int offset, int limit, string duration)
        {
            DateTime startMiladiDate;
            DateTime endMiladiDate = DateTime.Now;

            if (duration == "week")
            {
                int numOfWeek = ConvertDateTime.ConvertMiladiToShamsi(DateTime.Now, "dddd").GetNumOfWeek();
                startMiladiDate = DateTime.Now.AddDays((-1) * numOfWeek).Date + new TimeSpan(0, 0, 0);
            }

            else if (duration == "day")
                startMiladiDate = DateTime.Now.Date + new TimeSpan(0, 0, 0);

            else
            {
                string dayOfMonth = ConvertDateTime.ConvertMiladiToShamsi(DateTime.Now, "dd").Fa2En();
                startMiladiDate = DateTime.Now.AddDays((-1) * (int.Parse(dayOfMonth) - 1)).Date + new TimeSpan(0, 0, 0);
            }

            return await (from n in _context.News.Include(v => v.Visits).Include(l => l.Likes).Include(c => c.Comments)
                          where (n.PublishDateTime <= endMiladiDate && startMiladiDate <= n.PublishDateTime)
                          select (new NewsViewModel
                          {
                              NewsId = n.Id,
                              ShortTitle = n.Title.Length > 50 ? n.Title.Substring(0, 50) + "..." : n.Title,
                              Url = n.Url,
                              NumberOfVisit = n.Visits.Select(v => v.NumberOfVisit).Sum(),
                              NumberOfLike = n.Likes.Count(l => l.IsLike),
                              NumberOfDisLike = n.Likes.Count(l => l.IsLike == false),
                              NumberOfComment = n.Comments.Count(),
                              ImageName = n.ImageName,
                              PublishDateTime = n.PublishDateTime ?? new DateTime(01, 01, 01),
                          })).OrderByDescending(o => o.NumberOfComment).Skip(offset).Take(limit).AsNoTracking().ToListAsync();
        }

        public async Task<List<NewsViewModel>> MostPopularNews(int offset, int limit)
        {
            return await (from n in _context.News.Include(v => v.Visits).Include(l => l.Likes).Include(c => c.Comments)
                          where (n.IsPublish && n.PublishDateTime <= DateTime.Now)
                          select (new NewsViewModel
                          {
                              NewsId = n.Id,
                              ShortTitle = n.Title.Length > 50 ? n.Title.Substring(0, 50) + "..." : n.Title,
                              Url = n.Url,
                              Title = n.Title,
                              NumberOfVisit = n.Visits.Select(v => v.NumberOfVisit).Sum(),
                              NumberOfLike = n.Likes.Count(l => l.IsLike),
                              NumberOfDisLike = n.Likes.Count(l => l.IsLike == false),
                              NumberOfComment = n.Comments.Count(),
                              ImageName = n.ImageName,
                              PublishDateTime = n.PublishDateTime ?? new DateTime(01, 01, 01),
                          })).OrderByDescending(o => o.NumberOfLike).Skip(offset).Take(limit).AsNoTracking().ToListAsync();

        }
    }
}
