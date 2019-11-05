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
            if (movieRental.MovieIds.Count == 0)
                return BadRequest("Movie IDs invalid");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == movieRental.CustomerId);

            if (customer == null)
                return BadRequest("customer not found");

            var movies = _context.Movies.Where(m => movieRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != movieRental.MovieIds.Count)
                return BadRequest("One or more Movie Ids are invalid");

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
