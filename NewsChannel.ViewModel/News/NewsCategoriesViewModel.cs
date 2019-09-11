using System.Collections.Generic;
using NewsChannel.ViewModel.Category;

namespace NewsChannel.ViewModel.News
{
    public class NewsCategoriesViewModel
    {
        public NewsCategoriesViewModel(List<TreeViewCategory> categories, int[] categoryId)
        {
            Categories = categories;
            CategoryId = categoryId;
        }

        public List<TreeViewCategory> Categories { get; set; }
        public int[] CategoryId { get; set; }
    }
}
