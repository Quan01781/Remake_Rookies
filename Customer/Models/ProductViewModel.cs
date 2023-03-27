using SharedCommonModel.Product;

namespace Customer.Models
{
    public class ProductViewModel
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public List<ProductDto>? productDto { get; set; }
    }
}
