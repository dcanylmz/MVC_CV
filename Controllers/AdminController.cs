using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        GenericRepository<tbl_Admin> repo = new GenericRepository<tbl_Admin>();
        // GET: Admin
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(tbl_Admin d)
        {
            repo.TAdd(d);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            tbl_Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            tbl_Admin t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult UpdateAdmin(tbl_Admin p)
        {
            tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.Username = p.Username;
            t.Password = p.Password;

            repo.TUpdate(t);
            return RedirectToAction("Index");


        }
    }
}