using SharedCommonModel.Product;
using SharedCommonModel.Rating;
using SharedCommonModel;

namespace Customer.Services.Product
{
    public interface IProduct
    {
        public Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductDto> GetProductByIdAsync(int Id);
        public Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductByCategoryIdAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductDto> PostProductRatingAsync(RatingDto ratingDto);
    }
}
