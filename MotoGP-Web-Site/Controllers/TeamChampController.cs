using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class TeamChampController : Controller
    {
        TeamChampManager tcm = new TeamChampManager(new EFTeamChampRepository());
        TeamManager tm = new TeamManager(new EFTeamRepository());
        public IActionResult Team(int yearid)
        {
            var values = tcm.GetTeamsWithName().Where(x => x.YearId == yearid).ToList();
            ViewBag.year = yearid;
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam(int yearid)
        {
            var teams = tm.GetTeamsWithManufacturer();

            List<SelectListItem> teamValues = (from x in teams.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.TeamName + " - " + x.Manufacturer.ManuName,
                                                   Value = x.TeamId.ToString()
                                               }).ToList();

            ViewBag.t = teamValues;
            ViewBag.year = yearid;
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(TeamChampionship p)
        {
            tcm.TAdd(p);
            return RedirectToAction("Team", new { yearid = p.YearId });
        }

        public IActionResult DeleteTeam(int id)
        {
            var data = tcm.GetById(id);
            var year = data.YearId;
            tcm.TRemove(data);
            return RedirectToAction("Team", new { yearid = year });
        }

        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var data = tcm.GetByIdWithTeams(id);
            var teams = tm.GetTeamsWithManufacturer();

            List<SelectListItem> teamValues = (from x in teams.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.TeamName + " - " + x.Manufacturer.ManuName,
                                                   Value = x.TeamId.ToString()
                                               }).ToList();

            ViewBag.t = teamValues;

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateTeam(TeamChampionship p)
        {
            tcm.TUpdate(p);
            return RedirectToAction("Team", new { yearid = p.YearId });
        }
    }
}
