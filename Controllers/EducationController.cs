using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Experience
        EducationRepository repo = new EducationRepository();

        public ActionResult Index()
        {
            var edu = repo.List();
            return View(edu);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(tbl_Education d)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(d);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            tbl_Education t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            tbl_Education t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult UpdateEducation(tbl_Education p)
        {
            tbl_Education t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle1 = p.Subtitle1;
            t.Description = p.Description;
            t.GNA = p.GNA;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");


        }

    }
}