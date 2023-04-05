using Customer.Models;
using Customer.Services.Product;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SharedCommonModel.Product;
using System.Globalization;

namespace Customer.Pages
{
    public class Shopping_cartModel : PageModel
    {
        private readonly IProduct _productService;
        public Shopping_cartModel(IProduct productService)
        {
            _productService = productService;
        }

        public const string CARTKEY = "cart";
        public List<CartItem> cartItems = new List<CartItem>();
        internal List<CartItem> CartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
                
            }
            return cartItems;
        }


        public IActionResult OnGet()
        {
            cartItems = CartItems();

            return Page();
        }

        public IActionResult OnPostClearItem(int Id)
        {
            var item = cartItems.Find(p => p.product.Id == Id);
            cartItems.Remove(item);
            SaveCartSession(cartItems);
            //cartItems = CartItems();
            return Redirect("/Shopping_cart/");
        }

        public void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        public ProductDto Pro = new ProductDto();
        public async Task<IActionResult> OnPostAddToCart(int Id)
        {
            Pro = await _productService.GetProductByIdAsync(Id);

            if (cartItems.Count() > 0)
            {
                var cartitem = cartItems.Find(p => p.product.Id == Id);
                if (cartitem != null)
                {
                    // Đã tồn tại, tăng thêm 1
                    cartitem.quantity++;
                }
                else
                {
                    //  Thêm mới
                    cartItems.Add(new CartItem() { quantity = 1, product = Pro });
                }
            }
            else
            {
                cartItems.Add(new CartItem() { quantity = 1, product = Pro });
            }
            // Lưu cart vào Session
            SaveCartSession(cartItems);
            // Chuyển đến trang hiện thị Cart
            //return RedirectToAction(nameof(Cart));
            return Redirect("/Shopping_cart/");
        }
    }
}
