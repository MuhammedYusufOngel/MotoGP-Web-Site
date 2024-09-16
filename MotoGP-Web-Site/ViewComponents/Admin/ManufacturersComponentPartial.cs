using Microsoft.AspNetCore.Mvc;

namespace MotoGP_Web_Site.ViewComponents.Admin
{
    public class ManufacturersComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
