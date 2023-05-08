using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

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
                movies = movies
                    .Include(a => a.Actors)
                    .Include(g=>g.Genres)
                    .Include(p => p.Productions)
                    .Where(s => s.Name!.Contains(searchString));
            }

            return await movies
                .Include(a=>a.Actors)
                .Include(g => g.Genres)
                .Include(p => p.Productions)
                .ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetAiringMovies(string searchString)
        {
            var movies = from m in _cinemaManagementContext.Movies
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies
                    .Include(a => a.Actors)
                    .Include(g => g.Genres)
                    .Include(p => p.Productions)
                    .Where(s => s.Name!.Contains(searchString));
            }

            return await movies
                .Include(a => a.Actors)
                .Include(g => g.Genres)
                .Include(p => p.Productions)
                .Where(m => m.RunDate <= DateTime.Now && m.EndDate >= DateTime.Now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesPaginatedAsync(int? page, int pageSize, string searchString)
        {
            var movies = from m in _cinemaManagementContext.Movies
                         select m;
            int pageNumber = (page ?? 1);

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies
                    .Include(a => a.Actors)
                    .Include(g => g.Genres)
                    .Include(p => p.Productions)
                    .Where(s => s.Name!.Contains(searchString));
            }

            return await movies
                .Include(a => a.Actors)
                .Include(g => g.Genres)
                .Include(p => p.Productions)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync(string searchString)
        {
            var movies = from m in _cinemaManagementContext.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies
                    .Include(a => a.Actors)
                    .Include(g => g.Genres)
                    .Include(p => p.Productions)
                    .Where(s => s.Name!.Contains(searchString));
            }

            return await movies.CountAsync();
        }

        public async Task<Movie> GetMovieAsync(Guid movieId)
        {
            return await _cinemaManagementContext.Movies
                .Include(a=>a.Actors)
                .Include(g => g.Genres)
                .Include(p=> p.Productions)
                .Where(m => m.Id == movieId)
                .FirstOrDefaultAsync();
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
