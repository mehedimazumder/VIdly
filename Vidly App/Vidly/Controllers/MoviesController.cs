using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Random( )
        {
            var movie = new Movie() { Name = "Shrek"};

            var customers = new List<Customer>
            {
                new Customer() {Name = "Mehedi"},
                new Customer() {Name = "Rony"}
            };

            var viewModel = new RandomMovieViewModel
            {   
                Movie = movie,
                Customers =  customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek"},
                new Movie { Id = 2, Name = "Wall-e"}
            };
        }
    }
}