using SharedCommonModel.Product;

namespace Customer.Models
{
    public class CartItem
    {
        public int Quantity { set; get; }
        public ProductDto Product { set; get; } = new ProductDto();
    }
}
