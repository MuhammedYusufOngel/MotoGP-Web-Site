using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;
using NuGet.DependencyResolver;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace MotoGP_Web_Site.Controllers
{
	public class ResultController : Controller
	{
		ResultManager rm = new ResultManager(new EFResultRepository());
        DriverChampManager dcm = new DriverChampManager(new EFDriverChampRepository());
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

        public IActionResult ShowSessions(int trackid)
        {
            var values = rm.GetSessionsByTrackId(trackid).OrderByDescending(x => x.SessionId).ToList();
            ViewBag.trackid = trackid;
            return View(values);
        }

        public IActionResult GoToTrack()
        {
            using (var c = new Context())
            {
                var values = c.SessionTracks
                    .Include(x => x.Track)
                    .Include(x => x.Session)
                    .Include(x => x.Track.National)
                    .Select(x => x.Track)
                    .Distinct()
                    .OrderByDescending(x => x.TrackId)
                    .ToList();
                return View(values);
            }
        }

        public IActionResult ShowResult(int trackid, int sessionid)
        {
            var values = rm.GetDriversWithEveryPropByTrackAndSession(trackid, sessionid);
            ViewBag.trackid = trackid;
            ViewBag.sessionid = sessionid;
            return View(values);
        }

        public IActionResult DeleteResult(int id)
        {
            var data = rm.GetById(id);
            rm.TRemove(data);
            return RedirectToAction("GoToTrack");
        }

        [HttpGet]
        public IActionResult UpdateResult(int id)
        {
            var data = rm.GetById(id);

            var drivers = dcm.GetDriversWithName().OrderBy(x => x.Driver.Name);

            List<SelectListItem> driverValues = (from x in drivers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Driver.Name + " " + x.Driver.Surname,
                                                     Value = x.DriverChampId.ToString()
                                                 }).ToList();

            ViewBag.d = driverValues;
            
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateResult(Result p)
        {
            rm.TUpdate(p);
            return RedirectToAction("GoToTrack");
        }

        [HttpGet]
        public IActionResult AddResult(int trackid, int sessionid)
        {
            var time = rm.GetDriversWithEveryPropByTrackAndSession(trackid, sessionid).Select(x => x.Time).FirstOrDefault();

            ViewBag.time = time;

            ViewBag.trackid = trackid;
            ViewBag.sessionid = sessionid;

            var drivers = dcm.GetDriversWithName().OrderBy(x => x.Driver.Name);

            List<SelectListItem> driverValues = (from x in drivers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Driver.Name + " " + x.Driver.Surname,
                                                     Value = x.DriverChampId.ToString()
                                                 }).ToList();

            ViewBag.d = driverValues;

            using (var c = new Context())
            {
                var sessionTrackId = c.SessionTracks.Where(x => x.Track.TrackId == trackid && x.Session.SessionId == sessionid).Select(x => x.Id).FirstOrDefault();

                ViewBag.id = sessionTrackId;
            }


            return View();
        }

        [HttpPost]
        public IActionResult AddResult(Result p)
        {/*
            if(p.SessionTrack.Session.SessionId == 8)
            {
                if (p.Points == 1)
                    p.Points = 25;
                else if (p.Points == 2)
                    p.Points = 20;
                else if (p.Points == 3)
                    p.Points = 16;
                else if (p.Points == 4)
                    p.Points = 13;
                else if (p.Points == 5)
                    p.Points = 11;
                else if (p.Points == 6)
                    p.Points = 10;
                else if (p.Points == 7)
                    p.Points = 9;
                else if (p.Points == 8)
                    p.Points = 8;
                else if (p.Points == 9)
                    p.Points = 7;
                else if (p.Points == 10)
                    p.Points = 6;
                else if (p.Points == 11)
                    p.Points = 5;
                else if (p.Points == 12)
                    p.Points = 4;
                else if (p.Points == 13)
                    p.Points = 3;
                else if (p.Points == 14)
                    p.Points = 2;
                else if (p.Points == 15)
                    p.Points = 1;
                else
                    p.Points = 0;
            }
            if (p.SessionTrack.Session.SessionId == 6)
            {
                if (p.Points == 1)
                    p.Points = 12;
                else if (p.Points == 2)
                    p.Points = 9;
                else if (p.Points == 3)
                    p.Points = 7;
                else if (p.Points == 4)
                    p.Points = 6;
                else if (p.Points == 5)
                    p.Points = 5;
                else if (p.Points == 6)
                    p.Points = 4;
                else if (p.Points == 7)
                    p.Points = 3;
                else if (p.Points == 8)
                    p.Points = 2;
                else if (p.Points == 9)
                    p.Points = 1;
                else
                    p.Points = 0;
            }
            */


            TimeSpan tm = new TimeSpan();
            TimeSpan leaderTime = p.Time;

            var gap = p.Gap.Split(".");

            if(gap.Length == 2)
            {
                tm = new TimeSpan(0, 0, 0, Convert.ToInt32(gap[0]), Convert.ToInt32(gap[1]));
            }
            else if(gap.Length == 3)
            {
                tm = new TimeSpan(0, 0, Convert.ToInt32(gap[0]), Convert.ToInt32(gap[1]), Convert.ToInt32(gap[2]));
            }

            TimeSpan driverTime = leaderTime + tm;

            p.Time = driverTime;

            rm.TAdd(p);
            
            using(var c = new Context())
            {
                    var sessiontrack = c.SessionTracks
                    .Include(x => x.Session)
                    .Include(x => x.Track)
                    .Where(x => x.Id == p.SessionTrackId).FirstOrDefault();

                return RedirectToAction("AddResult", new { sessionid = sessiontrack.Session.SessionId, trackid = sessiontrack.Track.TrackId});
            }

        }
	}
}
