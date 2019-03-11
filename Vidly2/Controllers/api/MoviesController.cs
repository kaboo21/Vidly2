using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        //GET /API/movies
        public IHttpActionResult GetMovies(string query=null)
        {
            var movieQuery = _context.Movies.Include(c => c.Genre);
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(c => c.Name.Contains(query)).Where(c => c.NumberAvailable > 0);


            var MovieDtos = movieQuery.ToList().
                Select(Mapper.Map<Movie, MovieDto>);
            return Ok(MovieDtos);
        }

        //GET /API/movie/id
        public IHttpActionResult Getmovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /API/movie
        [HttpPost]
        public IHttpActionResult CreatMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /API/movie/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                NotFound();

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            movieDto.Id = movieInDb.Id;
            return Ok(movieDto);

        }

        //Delete /API/movie/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }

    }

}
