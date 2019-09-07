using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Tag;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        private readonly IUnitOfWork _uw;
        private const string TagNotFound = "برچسب یافت نشد.";
        private const string TagDuplicate = "نام برچسب تکراری است.";

        public TagController(IUnitOfWork uw)
        {
            _uw = uw;
            _uw.CheckArgumentIsNull(nameof(_uw));


        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetTags(string search, string order, int offset, int limit, string sort)
        {
            List<TagViewModel> tags;
            int total = _uw.BaseRepository<Tag>().CountEntities();
            if (!search.HasValue())
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "برچسب")
            {
                if (order == "asc")
                    tags = await _uw.TagRepository.GetPaginateTagsAsync(offset, limit, true, search);
                else
                    tags = await _uw.TagRepository.GetPaginateTagsAsync(offset, limit, false, search);
            }

            else
                tags = await _uw.TagRepository.GetPaginateTagsAsync(offset, limit, null, search);

            if (search != "")
                total = tags.Count();

            return Json(new { total = total, rows = tags });
        }



        [HttpGet]
        public async Task<IActionResult> RenderTag(int? tagId)
        {
            var tagViewModel = new TagViewModel();
            if (tagId != null)
            {
                var tag = await _uw.BaseRepository<Tag>().FindByIdAsync(tagId);

                tagViewModel.TagId = tag.Id;
                tagViewModel.TagName = tag.TagName;
            }
           
            return PartialView("_RenderTag", tagViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(TagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_uw.TagRepository.IsExistTag(viewModel.TagName, viewModel.TagId))
                    ModelState.AddModelError(string.Empty, TagDuplicate);
                else
                {
                    if (viewModel.TagId != null)
                    {
                        var tag = await _uw.BaseRepository<Tag>().FindByIdAsync(viewModel.TagId);
                        if (tag != null)
                        {
                            tag.TagName = viewModel.TagName;
                            _uw.BaseRepository<Tag>().Update(tag);
                            await _uw.Commit();
                            TempData["notification"] = EditSuccess;
                        }
                        else
                            ModelState.AddModelError(string.Empty, TagNotFound);
                    }

                    else
                    {
                        Tag tag = new Tag
                        {
                            TagName = viewModel.TagName
                        };
                        await _uw.BaseRepository<Tag>().CreateAsync(tag);
                        await _uw.Commit();
                        TempData["notification"] = InsertSuccess;
                    }
                }
            }

            return PartialView("_RenderTag", viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? tagId)
        {
            if (tagId == null)
                ModelState.AddModelError(string.Empty, TagNotFound);
            else
            {
                var tag = await _uw.BaseRepository<Tag>().FindByIdAsync(tagId);
                if (tag == null)
                    ModelState.AddModelError(string.Empty, TagNotFound);
                else
                    return PartialView("_DeleteConfirmation", tag);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Tag model)
        {

            var tag = await _uw.BaseRepository<Tag>().FindByIdAsync(model.Id);
            if (tag == null)
                ModelState.AddModelError(string.Empty, TagNotFound);
            else
            {
                _uw.BaseRepository<Tag>().Delete(tag);
                await _uw.Commit();
                TempData["notification"] = DeleteSuccess;
                return PartialView("_DeleteConfirmation", tag);
            }

            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("DeleteGroup")]
        public async Task<IActionResult> DeleteGroupConfirmed(int[] btSelectItem)
        {
            if (!btSelectItem.Any())
                ModelState.AddModelError(string.Empty, "هیچ برچسبی برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var tag = await _uw.BaseRepository<Tag>().FindByIdAsync(item);
                    _uw.BaseRepository<Tag>().Delete(tag);
                    await _uw.Commit();
                }
                TempData["notification"] = "حذف گروهی اطلاعات با موفقیت انجام شد.";
            }

            return PartialView("_DeleteGroup");
        }
    }
}