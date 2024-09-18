using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;

namespace MotoGP_Web_Site.ViewComponents.News
{
	public class RelatedNewsComponentPartial:ViewComponent
	{
		NewsManager nm = new NewsManager(new EFNewsRepository());
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
