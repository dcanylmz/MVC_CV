using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<tbl_About> repo = new GenericRepository<tbl_About> ();
        DB_CVEntities3 db = new DB_CVEntities3();
        [HttpGet]
        // GET: Hakkimda
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(tbl_About p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Description = p.Description;
            t.Adress = p.Adress;
            t.Mail = p.Mail;
            t.Phone = p.Phone;
            t.Photo = p.Photo;
            repo.TUpdate(t);
            return RedirectToAction("Index");


        }
    }
}