using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Genre> GetGenreAsync(Guid genreId);
        Task<Genre> CreateGenreAsync(Genre genre);
        Task AddGenreToMovieAsync(Movie movie, Genre genre);
        Task UpdateGenreAsync(Genre genre);
        void DeleteGenre(Genre genre);
        Task SaveAsync();
    }
}
