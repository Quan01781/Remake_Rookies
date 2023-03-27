using SharedCommonModel;
using SharedCommonModel.Product;

namespace API_web.Interfaces
{
    public interface IProduct
    {     
        public Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductDto> GetProductByIdAsync(int Id);
        public Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductByCategoryIdAsync(PagingRequestDto pagingRequestDto);

    }
}
