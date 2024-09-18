using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class SessionTrackController : Controller
    {
        SessionTrackManager stm = new SessionTrackManager(new EFSessionTrackRepository());
        TrackManager tm = new TrackManager(new EFTrackRepository());
        SessionManager sm = new SessionManager(new EFSessionRepository());
        YearManager ym = new YearManager(new EFYearRepository());
        public IActionResult SessionTracks(int yearid)
        {
            var values = stm.GetSessionTracksWithProperties(yearid);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSessionTrack()
        {
            var tracks = tm.GetAll();
            var sessions = sm.GetAll();
            var years = ym.GetAll();

            List<SelectListItem> trackValues = (from x in tracks.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.TrackName,
                                                       Value = x.TrackId.ToString()
                                                   }).ToList();

            List<SelectListItem> sessionValues = (from x in sessions.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.SessionName,
                                                    Value = x.SessionId.ToString()
                                                }).ToList();

            List<SelectListItem> yearValues = (from x in years.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.SeasonYear.ToString(),
                                                      Value = x.YearId.ToString()
                                                  }).ToList();

            ViewBag.t = trackValues;
            ViewBag.s = sessionValues;
            ViewBag.y = yearValues;

            return View();
        }

        [HttpPost]
        public IActionResult AddSessionTrack(SessionTrack p)
        {
            stm.TAdd(p);
            return RedirectToAction("SessionTracks", new { yearid = p.YearId });
        }
    }
}
