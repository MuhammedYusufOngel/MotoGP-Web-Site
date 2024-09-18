using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Controllers
{
    public class NationalController : Controller
    {
        NationalManager nm = new NationalManager(new EFNationalRepository());
        public IActionResult Nationals()
        {
            var data = nm.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddNational()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNational(National p)
        {
            nm.TAdd(p);
            return RedirectToAction("Nationals");
        }

        public IActionResult DeleteNational(int id)
        {
            var data = nm.GetById(id);
            nm.TRemove(data);
            return RedirectToAction("Nationals");
        }

        [HttpGet]
        public IActionResult UpdateNational(int id)
        {
            var data = nm.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateNational(National p)
        {
            nm.TUpdate(p);
            return RedirectToAction("Nationals");
        }
    }
}
