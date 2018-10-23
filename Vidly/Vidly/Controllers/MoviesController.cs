using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private AppContext _context;

        public MoviesController()
        {
            _context = new AppContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       

        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();                      

            return View();
        }

        public ActionResult New()
        {
            var vm = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",vm);
        }

        // Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var vm = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", vm);
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);                
            }
            else
            {
                var moviedb = _context.Movies.Single(m => m.Id == movie.Id);
                moviedb.Name = movie.Name;
                moviedb.NumberInStock = movie.NumberInStock;
                moviedb.ReleaseDate = movie.ReleaseDate;
                moviedb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies
        public ActionResult Details(int Id)
        {

            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(x => x.Id == Id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);


        }

        public ActionResult Edit(int Id)
        {

            var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);
            if (movie == null)
                return HttpNotFound();

            var vm = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", vm);

        }
    }
}