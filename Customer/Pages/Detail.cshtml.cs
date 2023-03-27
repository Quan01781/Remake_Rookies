using Customer.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SharedCommonModel.Product;
using SharedCommonModel.Rating;

namespace Customer.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IProduct _productService;

        public DetailModel(IProduct productService)
        {
            _productService = productService;
        }
        public ProductDto Pro = new ProductDto();
        public async Task<IActionResult> OnGet(int Id)
        {
            Pro = await _productService.GetProductByIdAsync(Id);
            return Page();
        }

        public async Task<IActionResult> OnPostRating(int Id)
        {
            string Comment = Request.Form["comment"];
            int Star = int.Parse(Request.Form["star"]);


            RatingDto ratingDto = new RatingDto()
            {
                Star = Star,
                Message = Comment,
                ProductId = Id,
                CreateDate = DateTime.Now
            };

            Pro = await _productService.PostProductRatingAsync(ratingDto);
            if (Pro != null)
            {
                return Redirect("/Detail/" + Pro.Id);
            }
            return Page();
        }
    }
}
