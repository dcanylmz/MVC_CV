using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<tbl_Certificates> repo = new GenericRepository<tbl_Certificates>();
        // GET: Skills
        public ActionResult Index()
        {
            var cert = repo.List();
            return View(cert);
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(tbl_Certificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var cert = repo.Find(x => x.ID == id);
            repo.TDelete(cert);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var cert = repo.Find(x => x.ID == id);
            return View(cert);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(tbl_Certificates p)
        {
            tbl_Certificates t = repo.Find(x => x.ID == p.ID);
            t.Description = p.Description;
            t.Certificate = p.Certificate;
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}