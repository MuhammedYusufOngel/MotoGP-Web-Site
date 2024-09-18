using Microsoft.AspNetCore.Mvc;
using MotoGP_Web_Site.Database.BusinessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;
using X.PagedList.Extensions;

namespace MotoGP_Web_Site.Controllers
{
    public class NewsController : Controller
    {
        NewsManager nm = new NewsManager(new EFNewsRepository());
        public IActionResult News(int page = 1)
        {
            var values = nm.GetAll().OrderByDescending(x => x.CreateDate).ToPagedList(page, 3);
            return View(values);
        }

        public IActionResult NewsDetail(int id)
        {
            var value = nm.GetById(id);
            ViewBag.title1 = value.Title;
            ViewBag.text = value.Text;
            ViewBag.date = value.CreateDate;
            ViewBag.image = value.ImageUrl;

            var labels = value.Label.Split(",");
            ViewBag.labels = labels;
            ViewBag.source = value.Source;

            return View();
        }

        public IActionResult NewsAdmin()
        {
            var values = nm.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNews(News p)
        {
            p.CreateDate = DateTime.Now;
            nm.TAdd(p);
            return RedirectToAction("NewsAdmin");
        }

        public IActionResult DeleteNews(int id)
        {
            var data = nm.GetById(id);
            nm.TRemove(data);
            return RedirectToAction("NewsAdmin");
        }

        [HttpGet]
        public IActionResult UpdateNews(int id)
        {
            var data = nm.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateNews(News p)
        {
            nm.TUpdate(p);
            return RedirectToAction("NewsAdmin");
        }
    }
}
