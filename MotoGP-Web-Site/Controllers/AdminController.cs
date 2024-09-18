using Microsoft.AspNetCore.Mvc;

namespace MotoGP_Web_Site.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
