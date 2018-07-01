using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImdbMVC2.Models;

namespace ImdbMVC2.Controllers
{
    public class ActorController : Controller
    {
        public Model1 _context;
        public ActorController()
        {
            _context = new Model1();
        }
        // GET: Actor
        public ActionResult Index()
        {
            var actors = _context.Actors.ToList();

            return View(actors);
        }

        [HttpPost]
        public ActionResult createActorAsync(Actors actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            string message = actor.id.ToString();
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public ActionResult Delete(int id)
        {
            Actors p = _context.Actors.Where(x => x.id == id).FirstOrDefault();
            _context.Actors.Remove(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Actors p)
        {
            if (p.id == 0)
                _context.Actors.Add(p);
            else
            {
                var actor = _context.Actors.Where(z => z.id == p.id).FirstOrDefault();
                actor.name = p.name;
                actor.sex = p.sex;
                actor.dob = p.dob;
                actor.bio = p.bio;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var p = _context.Actors.Where(z => z.id == id).FirstOrDefault();
            return View("New", p);
        }

        public ActionResult New()
        {


            return View();
        }

    }
}