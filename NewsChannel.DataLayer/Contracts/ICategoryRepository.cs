using System.Collections.Generic;
using System.Threading.Tasks;
using NewsChannel.DomainClasses.Business;
using NewsChannel.ViewModel.Category;

namespace NewsChannel.DataLayer.Contracts
{
    public interface ICategoryRepository
    {
        Category FindByCategoryName(string categoryName);
        List<TreeViewCategory> GetAllCategories();
        bool IsExistCategory(string categoryName, int? recentCategoryId);

        Task<List<CategoryViewModel>> GetPaginateCategoriesAsync(int offset, int limit, bool? categoryNameSortAsc, bool? parentCategoryNameSortAsc, string searchText);
    }
}
