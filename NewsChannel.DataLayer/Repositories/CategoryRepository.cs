using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        }
        public async Task<List<CategoryViewModel>> GetPaginateCategoriesAsync(int offset, int limit, bool? categoryNameSortAsc,bool? parentCategoryNameSortAsc, string searchText)
        {
            List<CategoryViewModel> categories;
            if (categoryNameSortAsc != null)
            {
                categories = await _context.Categories.Include(c => c.category)
                                    .Where(c => c.CategoryName.Contains(searchText) || c.category.CategoryName.Contains(searchText))
                                    .Select(c => new CategoryViewModel { CategoryId = c.Id, CategoryName = c.CategoryName, Url = c.Url, ParentCategoryName = c.category.CategoryName != null ? c.category.CategoryName : "-" })
                                    .OrderBy(c => (categoryNameSortAsc == true && categoryNameSortAsc != null) ? c.CategoryName : "")
                                    .OrderByDescending(c => (categoryNameSortAsc == false && categoryNameSortAsc != null) ? c.CategoryName : "").Skip(offset).Take(limit).AsNoTracking().ToListAsync();
            }

            else if (parentCategoryNameSortAsc!=null)
            {
                categories = await _context.Categories.Include(c => c.category)
                                   .Where(c => c.CategoryName.Contains(searchText) || c.category.CategoryName.Contains(searchText))
                                   .Select(c => new CategoryViewModel { CategoryId = c.Id, CategoryName = c.CategoryName, Url = c.Url, ParentCategoryName = c.category.CategoryName != null ? c.category.CategoryName : "-" })
                                   .OrderBy(c => (parentCategoryNameSortAsc == true && parentCategoryNameSortAsc != null) ? c.ParentCategoryName : "")
                                   .OrderByDescending(c => (parentCategoryNameSortAsc == false && parentCategoryNameSortAsc != null) ? c.ParentCategoryName : "").Skip(offset).Take(limit).AsNoTracking().ToListAsync();
            }
            else
            {
                categories = await _context.Categories.Include(c => c.category)
                                    .Where(c => c.CategoryName.Contains(searchText) || c.category.CategoryName.Contains(searchText))
                                    .Select(c => new CategoryViewModel {CategoryId= c.Id,CategoryName= c.CategoryName,Url=c.Url,ParentCategoryName=c.category.CategoryName!= null?c.category.CategoryName:"-"})
                                    .Skip(offset).Take(limit).AsNoTracking().ToListAsync();

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
            var subCategories = (from c in _context.Categories
                                 where (c.ParentCategoryId == category.Id)
                                 select new TreeViewCategory { Id = c.Id, Title = c.CategoryName }).ToList();
            foreach (var item in subCategories)
            {
                BindSubCategories(item);
                category.Subs.Add(item);
            }
        }

        public Category FindByCategoryName(string categoryName)
        {
           return  _context.Categories.FirstOrDefault(c => c.CategoryName == categoryName.TrimStart().TrimEnd());
        }

    }
}
