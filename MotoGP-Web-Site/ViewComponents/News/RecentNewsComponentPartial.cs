using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;

namespace MotoGP_Web_Site.ViewComponents.News
{
	public class RecentNewsComponentPartial:ViewComponent
	{
		NewsManager nm = new NewsManager(new EFNewsRepository());
		public IViewComponentResult Invoke()
		{
			var values = nm.GetAll().Take(6).ToList();
			return View(values);
		}
	}
}
