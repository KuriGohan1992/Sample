using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleManager.Services;
using SampleModels;
using static SampleModels.MovieModel;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return Ok(_movieService.GetAllMovies());
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie movie)
        {
            var existingMovie = _movieService.GetMovieById(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            _movieService.UpdateMovie(id, movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            _movieService.DeleteMovie(id);
            return NoContent();
        }
    }
}