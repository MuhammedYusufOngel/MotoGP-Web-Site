using Microsoft.AspNetCore.Mvc;

namespace MotoGP_Web_Site.ViewComponents.Default
{
	public class LastRaceComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
