using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedCommonModel.Product;
using SharedCommonModel;
using Customer.Services.Product;

namespace Customer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProduct _productService;
        public IndexModel(IProduct productService)
        {
            _productService = productService;

        }
        public ProductPagingDto productsNew = new ProductPagingDto();
        public async Task<IActionResult> OnGet()
        {
            PagingRequestDto pagingProductNew = new PagingRequestDto()
            {
                pageIndex = 1,
                pageSize = 8,
                sort = 1
            };
            productsNew = await _productService.GetAllProductsPaingAsync(pagingProductNew);
            return Page();
        }
    }
}