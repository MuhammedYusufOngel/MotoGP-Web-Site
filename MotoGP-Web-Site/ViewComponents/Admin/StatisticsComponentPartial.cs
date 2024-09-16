using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;

namespace MotoGP_Web_Site.ViewComponents.Admin
{
    public class StatisticsComponentPartial:ViewComponent
    {
        ResultManager rm = new ResultManager(new EFResultRepository());
        TrackManager tm = new TrackManager(new EFTrackRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.race = tm.GetById(rm.GetFinalTrackId()).TrackName;
            return View();
        }
    }
}
