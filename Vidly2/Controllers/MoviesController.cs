using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Randome
        public ActionResult Index ()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                
                new Movie {Id = 1, Name="Shreck"},
                new Movie {Id = 2, Name="Wall-e"}
            };
        }
    }
}