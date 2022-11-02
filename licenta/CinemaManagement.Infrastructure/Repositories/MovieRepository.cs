using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public MovieRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Movie>> GetMoviesAsync(string searchString)
        {
            var movies = from m in _cinemaManagementContext.Movies
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name!.Contains(searchString));
            }

            return await movies.ToListAsync();
        }
        public async Task<Movie> GetMovieAsync(Guid movieId)
        {
            return await _cinemaManagementContext.Movies.Include(g => g.Genres).Where(m => m.Id == movieId).FirstOrDefaultAsync();
        }
        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            _cinemaManagementContext.Movies.Add(movie);
            return movie;
        }
        public async Task UpdateMovieAsync(Movie movie)
        {
            _cinemaManagementContext.Movies.Update(movie);
        }
        public void DeleteMovie(Movie movie)
        {
            _cinemaManagementContext.Movies.Remove(movie);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
