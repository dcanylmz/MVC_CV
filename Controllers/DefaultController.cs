using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DB_CVEntities3 db = new DB_CVEntities3();
        // GET: Default
        public ActionResult Index()
        {
            var d = db.tbl_About.ToList();

            return View(d);
        }
        public PartialViewResult Experience()
        {
            var exp = db.tbl_Experience.OrderByDescending(x => x.ID).ToList(); 
            return PartialView(exp);
        }
        public PartialViewResult Education()
        {
            var edu = db.tbl_Education.OrderByDescending(x => x.ID).ToList();
            return PartialView(edu);
        }
        public PartialViewResult Skills()
        {
            var skill = db.tbl_Skills.ToList();
            return PartialView(skill);
        }
        public PartialViewResult Languages()
        {
            var lang = db.tbl_Languages.ToList();
            return PartialView(lang);
        }
        public PartialViewResult Certificates()
        {
            var cert = db.tbl_Certificates.ToList();
            return PartialView(cert);
        }
        [HttpGet]
        public PartialViewResult ContactMe()
        {
            var contact = db.tbl_Contact.ToList();
            return PartialView(contact);
        }
        [HttpPost]
        public PartialViewResult ContactMe(tbl_Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tbl_Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}