using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedCommonModel.Constants;
using SharedCommonModel;
using Customer.Models;
using Customer.Services.Product;

namespace Customer.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IProduct _productService;
        public SearchModel(IProduct prouctService)
        {
            _productService = prouctService;
        }

        public ProductViewModel productViewModel = new ProductViewModel();
        public PagingRequestDto pagingRequestDto = new PagingRequestDto();
        public async Task<IActionResult> OnGet(string searchstring, int pageIndex = 1, int pageLimit = Config.LIMIT)
        {
            pagingRequestDto.Search = searchstring;
            pagingRequestDto.pageIndex = pageIndex;
            pagingRequestDto.pageSize = pageLimit;

            var productPaging = await _productService.GetProductBySearchAsync(pagingRequestDto);
            productViewModel.pageSize = pageLimit;
            productViewModel.pageIndex = pageIndex;
            productViewModel.productDto = productPaging.products;
            productViewModel.totalCount = productPaging.totalCount;

            return Page();
        }

		public async Task<IActionResult> OnGetProductCategory(int Id, int pageIndex = 1, int pageLimit = Config.LIMIT)
		{
			pagingRequestDto = new PagingRequestDto()
			{
				pageIndex = pageIndex,
				pageSize = pageLimit,
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
