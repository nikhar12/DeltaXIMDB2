using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImdbMVC2.ViewModel;
using ImdbMVC2.Models;
using System.IO;

namespace ImdbMVC2.Controllers
{
  
    public class MoviesController : Controller
    {
        private Model1 _context;
        public MoviesController()
        {
            _context = new Model1();
        }

  

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.id == id);

            if (movie == null)
                return HttpNotFound();

            MovieProducerActor mpa = new MovieProducerActor()
            {
                Movies = movie,
                lActors = _context.Actors.ToList(),
                lProducer = _context.Producers.ToList()

            };


            return View("New",mpa);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)

        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }
        [HttpPost]
        public ActionResult Create(MovieProducerActor m,HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {
                var allactors = _context.Actors.ToList();
                var allproducer = _context.Producers.ToList();

                MovieProducerActor mpa = new MovieProducerActor();
                mpa.lProducer = allproducer;
                mpa.lActors = allactors;

                return View("New", mpa);
            }
            byte[] img = null;
                if (file != null && file.ContentLength > 0)
                {
                    img = ConvertToBytes(file);
                }
            
            //

            if (m.Movies.id == 0)
            {
                Movies movie = new Movies();

                movie.name = m.Movies.name;
                movie.plot = m.Movies.plot;
                movie.yor = m.Movies.yor;
                movie.poster = img;
                movie.producer = _context.Producers.Where(z => z.id == m.Movies.producer.id).First();

                foreach (var item in m.selectedActorID)
                {
                    var actor = _context.Actors.Where(z => z.id == item).First();
                    movie.Actors.Add(actor);
                }


                _context.Movies.Add(movie);
            }

            else
            {
                var mv = _context.Movies.Single(z => z.id == m.Movies.id);
                mv.name = m.Movies.name;
                mv.plot = m.Movies.plot;
                mv.yor = m.Movies.yor;
                mv.poster = img;
                mv.producer = _context.Producers.Where(z => z.id == m.Movies.producer.id).First();
                 foreach (var act in mv.Actors)
                {
                    mv.Actors.Remove(act);

                }

                foreach (var item in m.selectedActorID)
                {
                    var actor = _context.Actors.Where(z => z.id == item).First();
                    mv.Actors.Add(actor);
                }

            }
            try
            {
                _context.SaveChanges();
            }
            catch(Exception e)
            { Console.WriteLine(e); } 
            
            return RedirectToAction("Index");
        }
        public ActionResult New()
        {
            var allactors = _context.Actors.ToList();
            var allproducer = _context.Producers.ToList();

            MovieProducerActor m = new MovieProducerActor();
            m.lProducer = allproducer;
            m.lActors = allactors;
            return View(m);
        }
        public ActionResult Index()
        {
           

            var movies = (from m in _context.Movies
                         join p in _context.Producers on m.producer.id equals p.id
                         
                         select new { mname = m.name,mid=m.id, mposter = m.poster,pname = p.pname }).ToList();

            List<Movies> lmov = new List<Movies>();
                        
            foreach (var item in movies)
            {
                Movies m = new Movies();
        
                int mid = item.mid;

                var actorsinthemovie = _context.Actors.Where(a=>a.Movies.Any(z=>z.id==mid)).ToList();
                m.id = mid;
                m.name = item.mname;
                
                m.producer.pname = item.pname;
                m.Actors = actorsinthemovie;
                string imgDataURL = "";
                if (item.mposter != null)
                {
                    string imreBase64Data = Convert.ToBase64String(item.mposter);
                    imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);

                }
                m.imgurl = imgDataURL;

                lmov.Add(m);
            }


            
            //dynamic movies2 = (from mov in _context.Movies
            //            join p in _context.Producers on mov.producer.id equals p.id
            //          select new { mname=mov.name,pname=p.pname}).ToList();


            
            return View(lmov);
        }
    }
}