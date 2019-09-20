using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsChannel.DataLayer.Contracts;

namespace NewsChannel.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryList : ViewComponent
    {
        private readonly IUnitOfWork _uw;
        public CategoryList(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _uw.CategoryRepository.GetAllCategoriesAsync());
        }
    }
}
