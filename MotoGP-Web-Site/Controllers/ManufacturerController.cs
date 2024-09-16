using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class ManufacturerController : Controller
    {
        ManuManager mm = new ManuManager(new EFManuRepository());
        public IActionResult Index()
        {
            var values = mm.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddManufacturer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManufacturer(Manufacturer p)
        {
            mm.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteManufacturer(int id)
        {
            var data = mm.GetById(id);
            mm.TRemove(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateManufacturer(int id)
        {
            var data = mm.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateManufacturer(Manufacturer p)
        {
            mm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
