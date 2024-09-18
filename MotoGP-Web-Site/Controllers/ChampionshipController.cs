using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
	public class ChampionshipController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Drivers()
		{
			DriverChampManager dc = new DriverChampManager(new EFDriverChampRepository());
			return View(dc.GetDriversWithName());
		}

		public IActionResult Teams()
		{
			TeamChampManager tcm = new TeamChampManager(new EFTeamChampRepository());
			return View(tcm.GetTeamsWithName());
		}

		public IActionResult Manufacturers()
		{
			ManuChampManager mcm = new ManuChampManager(new EFManuChampRepository());
			return View(mcm.GetManusWithName());
		}

    }
}
