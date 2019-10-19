using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.Common;
using NewsChannel.Common.Attributes;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Newsletter;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class NewsletterController : BaseController
    {
        private readonly IUnitOfWork _uw;

        private const string EmailNotFound = "ایمیل یافت نشد...";
        public const string RegisterSuccess = "عضویت شما در خبرنامه با موفقیت انجام شد.";
        public NewsletterController(IUnitOfWork uw, IMapper mapper)
        {
            _uw = uw;
            _uw.CheckArgumentIsNull(nameof(_uw));

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetNewsletter(string search, string order, int offset, int limit, string sort)
        {
            List<NewsletterViewModel> newsletter;
            int total = _uw.BaseRepository<NewsLetter>().CountEntities();
            if (!search.HasValue())
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "Id")
            {
                if (order == "asc")
                    newsletter = _uw.NewsletterRepository.GetPaginateNewsletter(offset, limit, item => item.Email, item => "", search);
                else
                    newsletter = _uw.NewsletterRepository.GetPaginateNewsletter(offset, limit, item => "", item => item.Email, search);
            }

            else if (sort == "تاریخ عضویت")
            {
                if (order == "asc")
                    newsletter = _uw.NewsletterRepository.GetPaginateNewsletter(offset, limit, item => item.PersianRegisterDateTime, item => "", search);
                else
                    newsletter = _uw.NewsletterRepository.GetPaginateNewsletter(offset, limit, item => "", item => item.PersianRegisterDateTime, search);
            }

            else
                newsletter = _uw.NewsletterRepository.GetPaginateNewsletter(offset, limit, item => "", item => item.PersianRegisterDateTime, search);

            if (search != "")
                total = newsletter.Count();

            return Json(new { total = total, rows = newsletter });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                ModelState.AddModelError(string.Empty, EmailNotFound);
            else
            {
                var newsletter = await _uw.BaseRepository<NewsLetter>().FindByIdAsync(id);
                if (newsletter == null)
                    ModelState.AddModelError(string.Empty, EmailNotFound);
                else
                    return PartialView("_DeleteConfirmation", newsletter);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete"), AjaxOnly]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                ModelState.AddModelError(string.Empty, EmailNotFound);
            else
            {
                var newsletter = await _uw.BaseRepository<NewsLetter>().FindByIdAsync(id);
                if (newsletter == null)
                    ModelState.AddModelError(string.Empty, EmailNotFound);
                else
                {
                    _uw.BaseRepository<NewsLetter>().Delete(newsletter);
                    await _uw.Commit();
                    TempData["notification"] = DeleteSuccess;
                    return PartialView("_DeleteConfirmation", newsletter);
                }
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("DeleteGroup")]
        public async Task<IActionResult> DeleteGroupConfirmed(int[] btSelectItem)
        {
            if (!btSelectItem.Any())
                ModelState.AddModelError(string.Empty, "هیچ کاربری برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var newsletter = await _uw.BaseRepository<NewsLetter>().FindByIdAsync(item);
                    _uw.BaseRepository<NewsLetter>().Delete(newsletter);
                }

                await _uw.Commit();
                TempData["notification"] = "حذف گروهی اطلاعات با موفقیت انجام شد.";
            }

            return PartialView("_DeleteGroup");
        }

        public async Task<IActionResult> RegisterInNewsLetter(NewsletterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _uw.NewsletterRepository.FindNewsLetterByEmail(viewModel.Email);
                if (user == null)
                {
                    await _uw.BaseRepository<NewsLetter>().CreateAsync(new NewsLetter(viewModel.Email));
                    await _uw.Commit();
                    TempData["notification"] = RegisterSuccess;
                }
                else
                {
                    if (user.IsActive)
                        ModelState.AddModelError(string.Empty, $"شما با ایمیل '{viewModel.Email}' قبلا عضو خبرنامه شده اید.");
                    else
                    {
                        user.IsActive = true;
                        await _uw.Commit();
                        TempData["notification"] = RegisterSuccess;
                    }
                }
            }

            return PartialView("_RegisterInNewsLetter");
        }


        //public async Task<IActionResult> ActiveOrInactive(string email)
        //{
        //    if (!email.HasValue())
        //        ModelState.AddModelError(string.Empty, EmailNotFound);
        //    else
        //    {
        //        var newsletter = await _uw.BaseRepository<Newsletter>().FindByIdAsync(email);
        //        if (newsletter == null)
        //            ModelState.AddModelError(string.Empty, EmailNotFound);
        //        else
        //        {
        //            if (newsletter.IsActive == true)
        //                newsletter.IsActive = false;
        //            else
        //                newsletter.IsActive = true;
        //            await _uw.Commit();
        //        }
        //    }

        //    return PartialView();
        //}
    }
}