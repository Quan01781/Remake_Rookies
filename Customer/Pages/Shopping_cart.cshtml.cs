using Customer.Models;
using Customer.Services.Product;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SharedCommonModel.Product;
using System.Globalization;
using Customer.Extension;

namespace Customer.Pages
{
    public class Shopping_cartModel : PageModel
    {
        private readonly IProduct _productService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Shopping_cartModel(IProduct productService)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _productService = productService;
        }

        public List<CartItem> cart { get; set; }
        public double Total { get; set; } = 0;

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                Total = cart.Sum(i => i.Product.Price * i.Quantity);
            }
            else
            {
                cart = new List<CartItem>();
            }
        }


        public async Task<IActionResult> OnGetAddToCart(int Id)
        {
            ProductDto productModel = new ProductDto();
            productModel = await _productService.GetProductByIdAsync(Id);

            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
                cart.Add(new CartItem
                {
                    Product = productModel,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, Id);
                if (index == -1)
                {
                    cart.Add(new CartItem
                    {
                        Product = productModel,
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Shopping_cart");
        }


        public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Redirect("/Shopping_cart/");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Shopping_cart");
        }

        private int Exists(List<CartItem> cart, int Id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == Id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
