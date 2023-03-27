using Microsoft.AspNetCore.Mvc;

namespace Customer.Pages.Shared.Components.Shopping_cart
{
    public class Shopping_cartViewComponent : ViewComponent
    {
        public Shopping_cartViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
