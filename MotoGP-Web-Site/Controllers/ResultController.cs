using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using System.Runtime.CompilerServices;

namespace MotoGP_Web_Site.Controllers
{
	public class ResultController : Controller
	{
		ResultManager rm = new ResultManager(new EFResultRepository());
		public IActionResult Index()
		{
			var values = rm.GetDriversWithEveryProp();
            var trackValues = rm.GetTracks();
            var sessionValues = rm.GetSessions();
            var yearValues = rm.GetYears();

            List<SelectListItem> tracksValues = (from x in trackValues.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.TrackName,
                                                       Value = x.TrackId.ToString()
                                                   }).ToList();

            List<SelectListItem> sessionsValues = (from x in sessionValues.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.SessionName,
                                                    Value = x.SessionId.ToString()
                                                }).ToList();

            List<SelectListItem> yearsValues = (from x in yearValues.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.ToString(),
                                                       Value = x.ToString()
                                                   }).ToList();

            ViewBag.t = tracksValues;
            ViewBag.s = sessionsValues;
            ViewBag.y = yearsValues;

            return View(values);
		}

		public JsonResult GetResults(int trackid, int sessionId)
		{
			using(var c = new Context())
			{
                var values = c.Results
                    .Include(x => x.DriverChamp)
                    .Include(x => x.DriverChamp.Team)
                    .Include(x => x.DriverChamp.Driver)
                    .Include(x => x.DriverChamp.Driver.National)
                    .Include(x => x.SessionTrack)
                    .Include(x => x.SessionTrack.Session)
                    .Include(x => x.SessionTrack.Track)
                    .Where(x => x.SessionTrack.Track.TrackId == trackid && x.SessionTrack.Session.SessionId == sessionId).OrderBy(x => x.Time).ToList();
                return Json(values);
            }
		}
	}
}
