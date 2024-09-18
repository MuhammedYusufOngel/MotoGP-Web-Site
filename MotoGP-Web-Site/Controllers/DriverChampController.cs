using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class DriverChampController : Controller
    {
        DriverChampManager dcm = new DriverChampManager(new EFDriverChampRepository());
        DriverManager dm = new DriverManager(new EFDriverRepository());
        TeamChampManager tm = new TeamChampManager(new EFTeamChampRepository());
        public IActionResult Driver(int yearid)
        {
            var values = dcm.GetDriversWithName().Where(x => x.YearId == yearid).ToList();
            ViewBag.year = yearid;
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDriver(int yearid)
        {
            var drivers = dm.GetDriversWithNational().OrderBy(x => x.Name);
            var teams = tm.GetTeamsWithName().Where(x => x.YearId == yearid).ToList();

            List<SelectListItem> driverValues = (from x in drivers.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name + " " + x.Surname,
                                                       Value = x.DriverId.ToString()
                                                   }).ToList();

            List<SelectListItem> teamValues = (from x in teams.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Team.TeamName,
                                                     Value = x.Team.TeamId.ToString()
                                                 }).ToList();

            ViewBag.d = driverValues;
            ViewBag.t = teamValues;
            ViewBag.year = yearid;
            return View();
        }

        [HttpPost]
        public IActionResult AddDriver(DriverChampionship p)
        {
            dcm.TAdd(p);
            return RedirectToAction("Driver", new { yearid = p.YearId });
        }

        public IActionResult DeleteDriver(int id)
        {
            var data = dcm.GetById(id);
            var yearid = data.YearId;
            dcm.TRemove(data);
            return RedirectToAction("Driver", new { yearid = yearid });
        }

        [HttpGet]
        public IActionResult UpdateDriver(int id)
        {
            var drivers = dm.GetDriversWithNational();
            var teams = tm.GetTeamsWithName();

            List<SelectListItem> driverValues = (from x in drivers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name + " " + x.Surname,
                                                     Value = x.DriverId.ToString()
                                                 }).ToList();

            List<SelectListItem> teamValues = (from x in teams.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Team.TeamName,
                                                   Value = x.Team.TeamId.ToString()
                                               }).ToList();

            ViewBag.d = driverValues;
            ViewBag.t = teamValues;
            var data = dcm.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateDriver(DriverChampionship p)
        {
            dcm.TUpdate(p);
            return RedirectToAction("Driver", new { yearid = p.YearId });
        }
    }
}
