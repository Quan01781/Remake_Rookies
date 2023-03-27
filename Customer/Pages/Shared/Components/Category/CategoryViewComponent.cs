using Customer.Services.Category;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Pages.Shared.Components.Category
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategory _category;
        public CategoryViewComponent(ICategory category)
        {
            _category = category;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _category.GetCategories();
            return View(categories);
        }
    }
}
