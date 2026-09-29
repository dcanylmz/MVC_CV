using MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Repositories;
using Microsoft.Ajax.Utilities;
namespace MVC_CV.Controllers
{
    public class LanguageController : Controller
    {
        GenericRepository<tbl_Languages> repo = new GenericRepository<tbl_Languages>();
        // GET: Skills
        public ActionResult Index()
        {
            var lang = repo.List();
            return View(lang);
        }
        [HttpGet]
        public ActionResult AddLanguage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLanguage(tbl_Languages p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteLanguage(int id)
        {
            var lang = repo.Find(x => x.ID == id);
            repo.TDelete(lang);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateLanguage(int id)
        {
            var lang = repo.Find(x => x.ID == id);
            return View(lang);
        }
        [HttpPost]
        public ActionResult UpdateLanguage(tbl_Languages p)
        {
            tbl_Languages t = repo.Find(x => x.ID == p.ID);
            t.Desc1 = p.Desc1;
            t.Progress = p.Progress;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}