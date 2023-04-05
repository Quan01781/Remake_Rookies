using SharedCommonModel.Product;

namespace Customer.Models
{
    public class CartItem
    {
        public int quantity { set; get; }
        public ProductDto product { set; get; }
    }
}
