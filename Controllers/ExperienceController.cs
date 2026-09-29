using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var exp = repo.List();
            return View(exp);
        }
        [HttpGet]
        public ActionResult AddExp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExp(tbl_Experience d)
        {
            repo.TAdd(d);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExp(int id)
        {
            tbl_Experience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExp(int id)
        {
            tbl_Experience t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult UpdateExp(tbl_Experience p)
        {
            tbl_Experience t = repo.Find(x => x.ID == p.ID);
            t.Title= p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
            

        }
    }
}