using API_web.Models;
using SharedCommonModel;
using SharedCommonModel.Admin;
using SharedCommonModel.Product;

namespace API_web.Interfaces
{
    public interface IProduct
    {     
        public Task<ProductPagingDto> GetAllProductsPaingAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductDto> GetProductByIdAsync(int Id);
        public Task<ProductPagingDto> GetProductBySearchAsync(PagingRequestDto pagingRequestDto);
        public Task<ProductPagingDto> GetProductByCategoryIdAsync(PagingRequestDto pagingRequestDto);
        public Task<List<ProductAdmin>> GetAllProductsAdminAsync();
        public Task<Product> PostProductAsync(ProductAdmin addProduct);
        public Task<bool> PutProductAsync(int Id, ProductAdmin updateProduct);
        public string UploadFile(ImageDto file);
    }
}
