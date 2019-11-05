using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class MovieRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateMovieRentals(MovieRentalDto movieRental)
        {

            var customer = _context.Customers.Single(c => c.Id == movieRental.CustomerId);

            var movies = _context.Movies.Where(m => movieRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Not available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
               
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
