using Microsoft.AspNetCore.Mvc;

namespace MotoGP_Web_Site.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
