using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(string searchString);
        Task<Movie> GetMovieAsync(Guid movieId);
        Task<Movie> CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        void DeleteMovie(Movie movie);
        Task SaveAsync();
        Task<IEnumerable<Movie>> GetAiringMovies(string searchString);
        Task<IEnumerable<Movie>> GetMoviesPaginatedAsync(int? page, int pageSize, string searchString);
        Task<int> CountAsync(string searchString);
    }
}
