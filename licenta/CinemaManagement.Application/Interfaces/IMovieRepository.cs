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
    }
}
