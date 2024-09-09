using Microsoft.AspNetCore.Mvc;

namespace MotoGP_Web_Site.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
