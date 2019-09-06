using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.Common;
using NewsChannel.Common.Attributes;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Category;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        private readonly IUnitOfWork _uw;
        private const string CategoryNotFound = "دسته ی درخواستی یافت نشد.";
        private const string CategoryDuplicate = "دسته ی درخواستی تکراری می باشد.";
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork uw, IMapper mapper)
        {
            _uw = uw;
            _uw.CheckArgumentIsNull(nameof(_uw));
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories(string search, string order, int offset, int limit, string sort)
        {

            List<CategoryViewModel> categories;
            int total = _uw.BaseRepository<Category>().CountEntities();
            if (!search.HasValue())
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "دسته")
            {
                if (order == "asc")
                    categories = await _uw.CategoryRepository.GetPaginateCategoriesAsync(offset, limit, true, null, search);
                else
                    categories = await _uw.CategoryRepository.GetPaginateCategoriesAsync(offset, limit, false, null, search);
            }

            else if (sort == "دسته پدر")
            {
                if (order == "asc")
                    categories = await _uw.CategoryRepository.GetPaginateCategoriesAsync(offset, limit, null, true, search);
                else
                    categories = await _uw.CategoryRepository.GetPaginateCategoriesAsync(offset, limit, null, false, search);
            }

            else
                categories = await _uw.CategoryRepository.GetPaginateCategoriesAsync(offset, limit, null, null, search);

            if (search != "")
                total = categories.Count();

            return Json(new { total = total, rows = categories });
        }

        [HttpGet]
        [AjaxOnly]
        public async Task<IActionResult> RenderCategory(int? categoryId)
        {
            var categoryViewModel = new CategoryViewModel();
            List<TreeViewCategory> categories = _uw.CategoryRepository.GetAllCategories();
            if (categoryId != null)
            {
                var category = await _uw.BaseRepository<Category>().FindByIdAsync(categoryId);
                _uw._Context.Entry(category).Reference(c => c.category).Load();

                if (category.category != null)
                    categoryViewModel.ParentCategoryName = category.category.CategoryName;
                categoryViewModel.CategoryId = category.Id;
                categoryViewModel.CategoryName = category.CategoryName;
                categoryViewModel.Url = category.Url;


            }

            categoryViewModel.Categories = categories;
            return PartialView("_RenderCategory", categoryViewModel);
        }

        [HttpPost, AjaxOnly]
        public async Task<IActionResult> CreateOrUpdate(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_uw.CategoryRepository.IsExistCategory(viewModel.CategoryName, viewModel.CategoryId))
                    ModelState.AddModelError(string.Empty, CategoryDuplicate);
                else
                {
                    if (viewModel.CategoryId != null)
                    {
                        Category categoryModel = await _uw.BaseRepository<Category>().FindByIdAsync(viewModel.CategoryId);
                        if (categoryModel != null)
                        {
                            categoryModel.CategoryName = viewModel.CategoryName;
                            if (categoryModel.ParentCategoryId != null) categoryModel.ParentCategoryId = null;
                            categoryModel.Url = viewModel.Url;
                            _uw.BaseRepository<Category>().Update(categoryModel);
                            await _uw.Commit();
                            TempData["notification"] = "ویرایش اطلاعات با موفقیت انجام شد.";
                        }
                        else
                            ModelState.AddModelError(string.Empty, CategoryNotFound);
                    }
                    else
                    {
                        Category category = new Category();
                        if (viewModel.ParentCategoryName.HasValue())
                        {
                            Category parent = _uw.CategoryRepository.FindByCategoryName(viewModel.ParentCategoryName);
                            category.ParentCategoryId = parent.Id;
                        }
                        category.CategoryName = viewModel.CategoryName;
                        category.Url = viewModel.Url;
                        await _uw.BaseRepository<Category>().CreateAsync(category);
                        await _uw.Commit();
                        TempData["notification"] = "درج اطلاعات با موفقیت انجام شد.";

                    }

                }



            }

            return PartialView("_RenderCategory", viewModel);
        }

        [HttpGet, AjaxOnly]
        public async Task<IActionResult> Delete(int? categoryId)
        {
            if (categoryId == null)
                ModelState.AddModelError(string.Empty, CategoryNotFound);
            else
            {
                var category = await _uw.BaseRepository<Category>().FindByIdAsync(categoryId);

                if (category == null)
                    ModelState.AddModelError(string.Empty, CategoryNotFound);
                else
                    return PartialView("_DeleteConfirmation", category);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete"), AjaxOnly]
        public async Task<IActionResult> DeleteConfirmed(Category model)
        {

            var category = await _uw.BaseRepository<Category>().FindByIdAsync(model.Id);

            if (category == null)
                ModelState.AddModelError(string.Empty, CategoryNotFound);
            else
            {
                List<Category> childCategoryCount = _uw.BaseRepository<Category>()
                    .FindByConditionAsync(a => a.ParentCategoryId == category.Id).Result.ToList();
                if (childCategoryCount.Count != 0)
                {
                    _uw.BaseRepository<Category>().DeleteRange(childCategoryCount);
                }
                _uw.BaseRepository<Category>().Delete(category);
                await _uw.Commit();
                TempData["notification"] = "حذف اطلاعات با موفقیت انجام شد.";
                return PartialView("_DeleteConfirmation", category);
            }

            return PartialView("_DeleteConfirmation");
        }


        [HttpGet, AjaxOnly]
        public IActionResult DeleteGroup()
        {
            return PartialView("_DeleteGroup");
        }


        [HttpPost, ActionName("DeleteGroup"), AjaxOnly]
        public async Task<IActionResult> DeleteGroupConfirmed(int[] btSelectItem)
        {


            if (!btSelectItem.Any())
                ModelState.AddModelError(string.Empty, "هیچ دسته بندی برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var childCategory = _uw.BaseRepository<Category>().FindByConditionAsync(c => c.ParentCategoryId == item).Result.ToList();
                    if (childCategory.Count != 0)
                    {
                        _uw.BaseRepository<Category>().DeleteRange(childCategory);
                        await _uw.Commit();
                    }
                    var category = await _uw.BaseRepository<Category>().FindByIdAsync(item);
                    if (category != null)
                    {
                        _uw.BaseRepository<Category>().Delete(category);
                        await _uw.Commit();
                    }

                }
                TempData["notification"] = "حذف گروهی اطلاعات با موفقیت انجام شد.";
            }

            return PartialView("_DeleteGroup");
        }
    }
}
