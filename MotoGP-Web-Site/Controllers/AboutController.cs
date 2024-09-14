using Microsoft.AspNetCore.Mvc;

namespace MotoGP_Web_Site.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
