using Microsoft.AspNetCore.Mvc;

namespace Customer.Pages.Shared.Components.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        public FooterViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
