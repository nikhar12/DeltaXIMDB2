using ImdbMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbMVC2.Controllers
{
    public class ProducerController : Controller
    {
        private Model1 _context;
        public ProducerController()
        {
            _context = new Model1();
        }
        // GET: Producer
        public ActionResult Index()
        {
            var producers = _context.Producers.ToList();
            return View(producers);
        }

        public ActionResult Delete(int id)
        {
            Producer p = _context.Producers.Where(x => x.id == id).FirstOrDefault();
            //var moviewithp = _context.Movies.Where(x => x.producer.id == id).FirstOrDefault();
            //moviewithp.producer.id = 0;
            _context.Producers.Remove(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Producer p)
        {
            if (p.id == 0)
                _context.Producers.Add(p);
            else
            {
                var producer = _context.Producers.Where(z => z.id == p.id).FirstOrDefault();
                producer.pname = p.pname;
                producer.sex = p.sex;
                producer.dob = p.dob;
                producer.bio = p.bio;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var p = _context.Producers.Where(z => z.id == id).FirstOrDefault();
            return View("New",p);
        }
        
        public ActionResult New()
        {

            
            return View();
        }

        [HttpPost]
        public ActionResult createProducerAsync(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
            string message = producer.id.ToString();
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}