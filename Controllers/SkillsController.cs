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
    public class SkillsController : Controller
    {
        GenericRepository<tbl_Skills> repo = new GenericRepository<tbl_Skills>();
        // GET: Skills
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(tbl_Skills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult UpdateSkill(tbl_Skills p)
        {
            tbl_Skills t = repo.Find(x => x.ID == p.ID);
            t.Skills = p.Skills;
            t.Progress = p.Progress;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}