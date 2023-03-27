using Customer.Extension;
using SharedCommonModel.Product;
using SharedCommonModel.Rating;
using SharedCommonModel;

namespace Customer.Services.Product
{
    public class ProductServices : BaseServices, IProduct
    {
        public ProductServices(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        {
        }

        public async Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto)
        {
            var products = await httpClient.PostAsJsonAsync<PagingRequestDto, ProductPagingDto>("api/product/all-products/", pagingRequestDto);
            return products ?? new ProductPagingDto();
        }

        public async Task<ProductPagingDto> GetProductByCategoryIdAsync(PagingRequestDto pagingRequestDto)
        {
            var products = await httpClient.PostAsJsonAsync<PagingRequestDto, ProductPagingDto>("api/product/category-products/", pagingRequestDto);


            return products ?? new ProductPagingDto();
        }

        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            var product = await httpClient.GetAsJsonAsync<ProductDto>("api/product/" + Id);

            return product ?? new ProductDto();
        }

        public async Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto)
        {
            var products = await httpClient.PostAsJsonAsync<PagingRequestDto, ProductPagingDto>("api/product/search-product/", pagingRequestDto);
            return products ?? new ProductPagingDto();
        }

        public async Task<ProductDto> PostProductRatingAsync(RatingDto ratingDto)
        {
            var product = await httpClient.PostAsJsonAsync<RatingDto, ProductDto>("api/rating/add-rating/", ratingDto);


            return product ?? new ProductDto();
        }
    }
}
