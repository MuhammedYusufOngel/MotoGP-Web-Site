using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;

namespace MotoGP_Web_Site.ViewComponents.Default
{
	public class ChampionshipFirstThreeComponentPartial:ViewComponent
	{
		DriverChampManager dcm = new DriverChampManager(new EFDriverChampRepository());
		public IViewComponentResult Invoke()
		{
			var values = dcm.GetThreeDriversForHome();
			return View(values);
		}
	}
}
