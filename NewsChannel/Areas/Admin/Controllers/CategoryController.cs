using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Category;

namespace NewsChannel.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        private readonly IUnitOfWork _uw;
        private const string CategoryNotFound = "دسته ی درخواستی یافت نشد.";
        public CategoryController(IUnitOfWork uw)
        {
            _uw = uw;
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
        public async Task<IActionResult> RenderCategory(int? categoryId)
        {
            var categoryViewModel = new CategoryViewModel();
            List<TreeViewCategory> categories = _uw.CategoryRepository.GetAllCategories();
            if (categoryId != null)
            {
                var category = await _uw.BaseRepository<Category>().FindByIdAsync(categoryId);
                if (category != null)
                {
                    categoryViewModel.CategoryId = category.Id;
                    categoryViewModel.CategoryName = category.CategoryName;
                    categoryViewModel.ParentCategoryName = category.ParentCategoryId.ToString();
                    categoryViewModel.Url = category.Url;
                }
                else
                    ModelState.AddModelError(string.Empty, CategoryNotFound);
            }

            categoryViewModel.Categories = categories;
            return PartialView("_RenderCategory", categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
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

            return PartialView("_RenderCategory", viewModel);
        }
    }
}
