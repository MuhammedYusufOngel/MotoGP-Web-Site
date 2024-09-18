using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class ManuChampController : Controller
    {
        ManuChampManager mcm = new ManuChampManager(new EFManuChampRepository());
        ManuManager mm = new ManuManager(new EFManuRepository());
        public IActionResult Manufacturer(int yearid)
        {
            var datas = mcm.GetManusWithName().Where(x => x.YearId == yearid).ToList();
            ViewBag.year = yearid;
            return View(datas);
        }

        [HttpGet]
        public IActionResult AddManufacturer(int yearid)
        {
            var manufacturers = mm.GetAll();

            List<SelectListItem> manuValues = (from x in manufacturers.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ManuName,
                                                   Value = x.ManuId.ToString()
                                               }).ToList();

            ViewBag.m = manuValues;
            ViewBag.year = yearid; 
            return View();
        }

        [HttpPost]
        public IActionResult AddManufacturer(ManuChampionship p)
        {
            p.ManuId = p.ManufacturerManuId;
            mcm.TAdd(p);
            return RedirectToAction("Manufacturer", new { yearid = p.YearId });
        }

        public IActionResult DeleteManufacturer(int id)
        {
            var data = mcm.GetById(id);
            var year = data.YearId;
            mcm.TRemove(data);
            return RedirectToAction("Manufacturer", new {yearid = year });
        }

        [HttpGet]
        public IActionResult UpdateManufacturer(int id)
        {
            var manufacturers = mm.GetAll();

            List<SelectListItem> manuValues = (from x in manufacturers.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ManuName,
                                                   Value = x.ManuId.ToString()
                                               }).ToList();

            ViewBag.m = manuValues;

            var data = mcm.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateManufacturer(ManuChampionship p)
        {
            p.ManuId = p.ManufacturerManuId;
            mcm.TUpdate(p);
            return RedirectToAction("Manufacturer", new { yearid = p.YearId });
        }

        public IActionResult MakePassive(int id)
        {
            var data = mcm.MakePassive(id);
            mcm.TUpdate(data);
            return RedirectToAction("Manufacturer", new { yearid = data.YearId });
        }

        public IActionResult MakeActive(int id)
        {
            var data = mcm.MakeActive(id);
            mcm.TUpdate(data);
            return RedirectToAction("Manufacturer", new { yearid = data.YearId });
        }
    }
}
