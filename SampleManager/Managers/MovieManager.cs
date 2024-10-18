using SampleManager.Services;
using SampleModels;
using static SampleModels.MovieModel;

namespace SampleManager.Managers
{
    public class MovieManager : IMovieService
    {
        //Temporary data for testing before database connections
        private readonly List<Movie> _movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "The Shawshank Redemption", Rating = 9.3, YearReleased = 1994, Director = "Frank Darabont"},
            new Movie { Id = 2, Title = "The Thing", Rating = 8.2, YearReleased = 1982, Director = "John Carpenter"},
        };

        //Function that displays all students within the list
        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }
        //Function to display the details of the student if there is a matching Id
        public Movie GetMovieById(int id)
        {
            return _movies.FirstOrDefault(s => s.Id == id);
        }
        //Function that displays adds a students to the list
        public void AddMovie(Movie movie)
        {
            movie.Id = _movies.Max(s => s.Id) + 1;
            _movies.Add(movie);
        }
        //Function that update a student's information if it exists
        public void UpdateMovie(int id, Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(s => s.Id == id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Rating = movie.Rating;
                existingMovie.YearReleased = movie.YearReleased;
                existingMovie.Director = movie.Director;
            }
        }
        //Function that deletes a student from the list
        public void DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(s => s.Id == id);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }
    }
}