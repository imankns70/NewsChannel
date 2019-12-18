using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.Common.Attributes;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.DynamicAccess;
using NewsChannel.ViewModel.News;

namespace NewsChannel.Areas.Admin.Controllers
{
    [DisplayName("صفحه اخبار")]
    public class NewsController : BaseController
    {
        private readonly IUnitOfWork _uw;
        private readonly IHostingEnvironment _env;
        private const string NewsNotFound = "خبر یافت نشد.";
        private readonly IMapper _mapper;

        public NewsController(IUnitOfWork uw, IMapper mapper, IHostingEnvironment env)
        {
            _uw = uw;
            _uw.CheckArgumentIsNull(nameof(_uw));

            _env = env;
            _env.CheckArgumentIsNull(nameof(_env));

            _mapper = mapper;
            _mapper.CheckArgumentIsNull(nameof(_mapper));
        }

        [HttpGet, DisplayName("نمایش اخبار")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission,Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetNews(string search, string order, int offset, int limit, string sort)
        {
            List<NewsViewModel> news;
            int total = _uw.BaseRepository<News>().CountEntities();
            if (!search.HasValue())
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "ShortTitle")
            {
                if (order == "asc")
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => item.First().Title, item => "", search, null, null);
                else
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => "", item => item.First().Title, search, null, null);
            }

            else if (sort == "بازدید")
            {
                if (order == "asc")
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => item.First().NumberOfVisit, item => "", search, null, null);
                else
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => "", item => item.First().NumberOfVisit, search, null, null);
            }

            else if (sort == "لایک")
            {
                if (order == "asc")
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => item.First().NumberOfLike, item => "", search, null, null);
                else
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => "", item => item.First().NumberOfLike, search, null, null);
            }

            else if (sort == "دیس لایک")
            {
                if (order == "asc")
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => item.First().NumberOfDisLike, item => "", search, null, null);
                else
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => "", item => item.First().NumberOfDisLike, search, null, null);
            }

            else if (sort == "تاریخ انتشار")
            {
                if (order == "asc")
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => item.First().PersianPublishDate, item => "", search, null, null);
                else
                    news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => "", item => item.First().PersianPublishDate, search, null, null);
            }

            else
                news = _uw.NewsRepository.GetPaginateNews(offset, limit, item => "", item => item.First().PersianPublishDate, search, null, null);
            if (search != "")
                total = news.Count();

            return Json(new { total = total, rows = news });
        }

        [HttpGet, DisplayName("درج و ویرایش")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> CreateOrUpdate(int? newsId)
        {
            NewsViewModel newsViewModel = new NewsViewModel();
            newsViewModel.TagNames = _uw._Context.Tags.Select(t => t.TagName).ToList();
            newsViewModel.NewsCategoriesViewModel = new NewsCategoriesViewModel(await _uw.CategoryRepository.GetAllCategoriesAsync(), null);
            if (newsId != null)
            {
                var news = await (from n in _uw._Context.News.Include(c => c.NewsCategories)
                                  join w in _uw._Context.NewsTags on n.Id equals w.NewsId into bc
                                  from bct in bc.DefaultIfEmpty()
                                  join t in _uw._Context.Tags on bct.TagId equals t.Id into cg
                                  from cog in cg.DefaultIfEmpty()
                                  where (n.Id == newsId)
                                  select new NewsViewModel
                                  {
                                      NewsId = n.Id,
                                      Title = n.Title,
                                      Description = n.Description,
                                      PublishDateTime = n.PublishDateTime,
                                      IsPublish = n.IsPublish,
                                      ImageName = n.ImageName,
                                      IsInternal = n.IsInternal,
                                      NewsCategories = n.NewsCategories,
                                      Url = n.Url,
                                      Abstract = n.Abstract,
                                      NameOfTags = cog != null ? cog.TagName : "",
                                  }).ToListAsync();

                if (news != null)
                {
                    newsViewModel = news.FirstOrDefault();
                    if (news.FirstOrDefault()?.PublishDateTime > DateTime.Now)
                    {
                        if (newsViewModel != null)
                        {
                            newsViewModel.FuturePublish = true;

                            newsViewModel.PersianPublishDate = news.FirstOrDefault()?.PublishDateTime
                                .ConvertMiladiToShamsi("yyyy/MM/dd");
                            var publishDateTime = news.FirstOrDefault()?.PublishDateTime;
                            if (publishDateTime != null)
                                newsViewModel.PersianPublishTime =
                                    publishDateTime.Value.TimeOfDay.ToString();
                        }
                    }

                    if (newsViewModel != null)
                    {
                        newsViewModel.NewsCategoriesViewModel = new NewsCategoriesViewModel(
                           await _uw.CategoryRepository.GetAllCategoriesAsync(),
                            news.FirstOrDefault()?.NewsCategories.Select(n => n.CategoryId).ToArray());
                        newsViewModel.NameOfTags = news.Select(t => t.NameOfTags).ToArray().CombineWith(',');
                    }
                }

            }

            return View(newsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(NewsViewModel viewModel, string submitButton)
        {
            viewModel.UserId = User.Identity.GetUserId<int>();
            News news = new News();
            viewModel.NewsCategoriesViewModel = new NewsCategoriesViewModel(await _uw.CategoryRepository.GetAllCategoriesAsync(), viewModel.CategoryIds);
            if (!viewModel.FuturePublish)
            {
                ModelState.Remove("PersianPublishTime");
                ModelState.Remove("PersianPublishDate");
            }
            if (viewModel.NewsId != null)
                ModelState.Remove("ImageFile");

            if (ModelState.IsValid)
            {
                if (submitButton != "ذخیره پیش نویس")
                    viewModel.IsPublish = true;

                if (viewModel.ImageFile != null)
                    viewModel.ImageName = $"news-{StringExtensions.GenerateId(10)}.jpg";

                if (viewModel.NewsId != null)
                {

                    news = _uw.BaseRepository<News>().FindByConditionAsync(n => n.Id == viewModel.NewsId, null, n => n.NewsCategories, n => n.NewsTags).Result.FirstOrDefault();
                    if (news == null)
                        ModelState.AddModelError(string.Empty, NewsNotFound);
                    else
                    {
                        if (viewModel.IsPublish && news.IsPublish == false)
                            viewModel.PublishDateTime = DateTime.Now;

                        if (viewModel.IsPublish && news.IsPublish == true)
                        {
                            if (viewModel.PersianPublishDate.HasValue())
                            {
                                var persianTimeArray = viewModel.PersianPublishTime.Split(':');
                                viewModel.PublishDateTime = viewModel.PersianPublishDate.ConvertShamsiToMiladi().Date + new TimeSpan(int.Parse(persianTimeArray[0]), int.Parse(persianTimeArray[1]), 0);
                            }
                            else
                                viewModel.PublishDateTime = news.PublishDateTime;
                        }

                        if (viewModel.ImageFile != null)
                        {
                            viewModel.ImageFile.UploadFileBase64($"{_env.WebRootPath}/newsImage/{viewModel.ImageName}");
                            FileExtensions.DeleteFile($"{_env.WebRootPath}/newsImage/{news.ImageName}");
                        }

                        else
                            viewModel.ImageName = news.ImageName;

                        if (viewModel.NameOfTags.HasValue())

                            news.NewsTags = await _uw.TagRepository.InsertNewsTags(viewModel.NameOfTags.Split(','), news.Id);

                        if (viewModel.CategoryIds != null)

                            news.NewsCategories = viewModel.CategoryIds.Select(c => new NewsCategory { CategoryId = c, NewsId = news.Id }).ToList();

                        news.Description = viewModel.Description;
                        news.ImageName = viewModel.ImageName;
                        news.Url = viewModel.Url;
                        if (viewModel.IsInternal != null) news.IsInternal = viewModel.IsInternal.Value;
                        news.IsPublish = viewModel.IsPublish;
                        news.PublishDateTime = viewModel.PublishDateTime;
                        news.Title = viewModel.Title;
                        news.UserId = viewModel.UserId;
                        news.Abstract = viewModel.Abstract;




                        _uw.BaseRepository<News>().Update(news);
                        await _uw.Commit();
                        ViewBag.Alert = "ذخیره تغییرات با موفقیت انجام شد.";
                        viewModel.NewsCategoriesViewModel.CategoryId = viewModel.CategoryIds;
                    }
                }

                else
                {
                    viewModel.ImageFile.UploadFileBase64($"{_env.WebRootPath}/newsImage/{viewModel.ImageName}");


                    if (viewModel.IsPublish)
                    {
                        if (!viewModel.PersianPublishDate.HasValue())
                            viewModel.PublishDateTime = DateTime.Now;
                        else
                        {
                            var persianTimeArray = viewModel.PersianPublishTime.Split(':');
                            viewModel.PublishDateTime = viewModel.PersianPublishDate.ConvertShamsiToMiladi().Date + new TimeSpan(int.Parse(persianTimeArray[0]), int.Parse(persianTimeArray[1]), 0);
                        }
                    }

                    news.Description = viewModel.Description;
                    news.ImageName = viewModel.ImageName;
                    news.Url = viewModel.Url;
                    if (viewModel.IsInternal != null) news.IsInternal = viewModel.IsInternal.Value;
                    news.IsPublish = viewModel.IsPublish;
                    news.PublishDateTime = viewModel.PublishDateTime;
                    news.Title = viewModel.Title;
                    news.UserId = viewModel.UserId;
                    news.Abstract = viewModel.Abstract;
                    news.NewsTags = viewModel.NewsTags;
                    news.NewsCategories = viewModel.NewsCategories;

                    await _uw.BaseRepository<News>().CreateAsync(news);

                    if (viewModel.NameOfTags.HasValue())
                        news.NewsTags = await _uw.TagRepository.InsertNewsTags(viewModel.NameOfTags.Split(","), null);
                    if (viewModel.CategoryIds != null)
                        news.NewsCategories = viewModel.CategoryIds.Select(c => new NewsCategory { CategoryId = c }).ToList();
                    else
                        viewModel.NewsCategories = null;
                    await _uw.Commit();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }


        [HttpGet, AjaxOnly]
        public async Task<IActionResult> Delete(int? newsId)
        {
            if (newsId == null)
                ModelState.AddModelError(string.Empty, NewsNotFound);
            else
            {
                var news = await _uw.BaseRepository<News>().FindByIdAsync(newsId);
                if (news == null)
                    ModelState.AddModelError(string.Empty, NewsNotFound);
                else
                    return PartialView("_DeleteConfirmation", news);
            }
            return PartialView("_DeleteConfirmation");
        }

        [HttpPost, ActionName("Delete"), AjaxOnly, DisplayName("حذف")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                ModelState.AddModelError(string.Empty, NewsNotFound);

            var news = await _uw.BaseRepository<News>().FindByIdAsync(id);
            if (news == null)
                ModelState.AddModelError(string.Empty, NewsNotFound);
            else
            {
                _uw.BaseRepository<News>().Delete(news);
                await _uw.Commit();
                FileExtensions.DeleteFile($"{_env.WebRootPath}/newsImage/{news.ImageName}");
                TempData["notification"] = DeleteSuccess;
                return PartialView("_DeleteConfirmation", news);
            }

            return PartialView("_DeleteConfirmation");
        }

      
        [HttpPost, ActionName("DeleteGroup"), AjaxOnly, DisplayName("حذف گروهی")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> DeleteGroupConfirmed(int[] btSelectItem)
        {
            if (btSelectItem.Any())
                ModelState.AddModelError(string.Empty, "هیچ خبری برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var news = await _uw.BaseRepository<News>().FindByIdAsync(item);
                    _uw.BaseRepository<News>().Delete(news);
                    FileExtensions.DeleteFile($"{_env.WebRootPath}/newsImage/{news.ImageName}");
                }
                await _uw.Commit();
                TempData["notification"] = "حذف گروهی اطلاعات با موفقیت انجام شد.";
            }

            return PartialView("_DeleteGroup");
        }
    }
}