using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;

namespace MotoGP_Web_Site.Controllers
{
	public class ScheduleController : Controller
	{
		TrackManager tm = new TrackManager(new EFTrackRepository());
		public IActionResult Index()
		{
			var values = tm.GetTracksWithNation();
			return View(values);
		}
	}
}
