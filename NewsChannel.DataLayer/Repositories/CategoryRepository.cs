using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsChannel.Common;
using NewsChannel.DataLayer.Contracts;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Category;

namespace NewsChannel.DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewsDbContext _context;
       public CategoryRepository(NewsDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));

          
        }

        public async Task<List<CategoryViewModel>> GetPaginateCategoriesAsync(int offset, int limit, bool? categoryNameSortAsc,bool? parentCategoryNameSortAsc, string searchText)
        {
            List<CategoryViewModel> categories= await _context.Categories.Include(c => c.category)
                                    .Where(c => c.CategoryName.Contains(searchText) || c.category.CategoryName.Contains(searchText))
                                    .Select(x=> new CategoryViewModel
                                    {
                                        CategoryId = x.Id,
                                        CategoryName = x.CategoryName,
                                        ParentCategoryName = x.category.CategoryName,
                                        Url = x.Url,
                                        })
                                    //.ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
                                    .Skip(offset).Take(limit).AsNoTracking().ToListAsync();

            if (categoryNameSortAsc != null)
                categories = categories.OrderBy(c => (categoryNameSortAsc == true) ? c.CategoryName : "")
                                     .ThenByDescending(c => (categoryNameSortAsc == false) ? c.CategoryName : "").ToList();

            else if (parentCategoryNameSortAsc != null)
            {
                categories = categories.OrderBy(c => (parentCategoryNameSortAsc == true) ? c.ParentCategoryName : "")
                                   .ThenByDescending(c => (parentCategoryNameSortAsc == false) ? c.ParentCategoryName : "").ToList();

            }

            foreach (var item in categories)
                item.Row = ++offset;

            return categories;
        }


        public List<TreeViewCategory> GetAllCategories()
        {
            var categories = (from c in _context.Categories
                              where (c.ParentCategoryId == null)
                              select new TreeViewCategory { Id = c.Id, Title = c.CategoryName }).ToList();
            foreach (var item in categories)
            {
                BindSubCategories(item);
            }

            return categories;
        }

        public void BindSubCategories(TreeViewCategory category)
        {
            var SubCategories = (from c in _context.Categories
                                 where (c.ParentCategoryId == category.Id)
                                 select new TreeViewCategory { Id = c.Id, Title = c.CategoryName }).ToList();
            foreach (var item in SubCategories)
            {
                BindSubCategories(item);
                category.Subs.Add(item);
            }
        }

        public Category FindByCategoryName(string categoryName)
        {
           return  _context.Categories.FirstOrDefault(c => c.CategoryName == categoryName.TrimStart().TrimEnd());
        }


        public bool IsExistCategory(string categoryName, int? recentCategoryId)
        {
            if (recentCategoryId==null)
                return _context.Categories.Any(c => c.CategoryName.Trim().Replace(" ", "") == categoryName.Trim().Replace(" ", ""));
            else
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryName.Trim().Replace(" ", "") == categoryName.Trim().Replace(" ", ""));
                if (category == null)
                    return false;
                else
                {
                    if (category.Id != recentCategoryId)
                        return true;
                    else
                        return false;
                }
            }
        }


    }
}
