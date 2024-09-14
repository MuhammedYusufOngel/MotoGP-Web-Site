using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;

namespace MotoGP_Web_Site.ViewComponents.Default
{
    public class NewsComponentPartial:ViewComponent
    {
        NewsManager nm = new NewsManager(new EFNewsRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.getSixNewsForHome();
            return View(values);
        }
    }
}
