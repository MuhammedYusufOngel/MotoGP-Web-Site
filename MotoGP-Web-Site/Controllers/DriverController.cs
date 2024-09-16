using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class DriverController : Controller
    {
        DriverManager dm = new DriverManager(new EFDriverRepository());
        NationalManager nm = new NationalManager(new EFNationalRepository());
        public IActionResult Index()
        {
            var values = dm.GetDriversWithNational();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDriver()
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
        public IActionResult AddDriver(Driver p)
        {
            dm.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDriver(int id)
        {
            var data = dm.GetById(id);
            dm.TRemove(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDriver(int id)
        {
            var nationals = nm.GetAll();

            List<SelectListItem> nationalValues = (from x in nationals.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.NationalName,
                                                       Value = x.NationalId.ToString()
                                                   }).ToList();

            ViewBag.n = nationalValues;
            var data = dm.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateDriver(Driver p)
        {
            dm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
