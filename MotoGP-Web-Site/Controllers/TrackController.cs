using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class TrackController : Controller
    {
        TrackManager tm = new TrackManager(new EFTrackRepository());
        NationalManager nm = new NationalManager(new EFNationalRepository());
        public IActionResult Tracks()
        {
            var values = tm.GetTracksWithNation();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTrack()
        {
            var nationals = nm.GetAll();

            List<SelectListItem> nationalValues = (from x in nationals.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.NationalName,
                                                   Value = x.NationalId.ToString()
                                               }).ToList();

            ViewBag.n = nationalValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddTrack(Track p)
        {
            tm.TAdd(p);
            return RedirectToAction("Tracks");
        }

        public IActionResult DeleteTrack(int id)
        {
            var data = tm.GetById(id);
            tm.TRemove(data);
            return RedirectToAction("Tracks");
        }

        [HttpGet]
        public IActionResult UpdateTrack(int id)
        {
            var nationals = nm.GetAll();

            List<SelectListItem> nationalValues = (from x in nationals.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NationalName,
                                                       Value = x.NationalId.ToString()
                                                   }).ToList();

            ViewBag.n = nationalValues;

            var data = tm.GetByIdWithNation(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateTrack(Track p)
        {
            tm.TUpdate(p);
            return RedirectToAction("Tracks");
        }
    }
}
