using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class TeamController : Controller
    {
        TeamManager tm = new TeamManager(new EFTeamRepository());
        ManuManager mm = new ManuManager(new EFManuRepository());
        public IActionResult Index()
        {
            var values = tm.GetTeamsWithManufacturer();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            var manufacturers = mm.GetAll();

            List<SelectListItem> manuValues = (from x in manufacturers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ManuName,
                                                     Value = x.ManuId.ToString()
                                                 }).ToList();

            ViewBag.m = manuValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team p)
        {
            tm.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTeam(int id)
        {
            var data = tm.GetById(id);
            tm.TRemove(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var manufacturers = mm.GetAll();

            List<SelectListItem> manuValues = (from x in manufacturers.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ManuName,
                                                   Value = x.ManuId.ToString()
                                               }).ToList();

            ViewBag.m = manuValues;

            var data = tm.GetByIdWithManufacturer(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateTeam(Team p)
        {
            tm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
