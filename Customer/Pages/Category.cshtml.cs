using Customer.Models;
using Customer.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedCommonModel;
using SharedCommonModel.Constants;

namespace Customer.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProduct _productService;

        public CategoryModel(IProduct productService) 
        {
            _productService= productService;
        }

		public ProductViewModel productViewModel = new ProductViewModel();
        PagingRequestDto pagingRequestDto;
        public async Task<IActionResult> OnGetProductCategory(int Id, int pageIndex = 1, int pageLimit = Config.LIMIT)
        {
            pagingRequestDto = new PagingRequestDto()
            { 
                pageIndex = pageIndex,
                pageSize  = pageLimit,
                id = Id
            };

            var productPaging = await _productService.GetProductByCategoryIdAsync(pagingRequestDto);
            productViewModel.pageIndex = pageIndex;
            productViewModel.pageSize = pageLimit;
            productViewModel.totalCount = productPaging.totalCount;
            productViewModel.productDto = productPaging.products;
            return Page();

        }
    }
}
