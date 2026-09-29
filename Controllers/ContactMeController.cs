using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace MVC_CV.Controllers
{
    public class ContactMeController : Controller
    {
        // GET: ContactMe
        GenericRepository<tbl_Contact> repo = new GenericRepository<tbl_Contact>();
        public ActionResult Index()
        {
            var cont = repo.List();

            return View(cont);
        }
        public ActionResult DeleteContactMe(int id)
        {
            var cont = repo.Find(x => x.ID == id);
            repo.TDelete(cont);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContactMe(int id)
        {
            var cont = repo.Find(x => x.ID == id);
            return View(cont);
        }
        [HttpPost]
        public ActionResult UpdateContactMe(tbl_Contact p)
        {
            tbl_Contact t = repo.Find(x => x.ID == p.ID);
            t.NameSurname = p.NameSurname;
            t.Mail = p.Mail;
            t.Subject = p.Subject;
            t.Message = p.Message;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}