using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenresAsync(int? page, int pageSize);
        Task<Genre> GetGenreAsync(Guid genreId);
        Task<Genre> CreateGenreAsync(Genre genre);
        Task AddGenreToMovieAsync(Movie movie, Genre genre);
        Task UpdateGenreAsync(Genre genre);
        void DeleteGenre(Genre genre);
        Task SaveAsync();
        Task<ICollection<Genre>> GetGenresById(List<Guid> ids);
        Task<int> CountAsync();
        Task<IEnumerable<Genre>> GetGenresWithoutPagination();
    }
}
