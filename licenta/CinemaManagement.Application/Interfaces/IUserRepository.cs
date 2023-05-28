using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid userId);
        void DeleteUser(User user);
        Task SaveAsync();
        Task<IEnumerable<Movie>> GetUsersWatchedMovies(string username);
        void AddMovieToWatched(User user, Movie movie);
        void RemoveMovieFromWatched(User user, Movie movie);
        Task UpdateUserAsync(User user);
        Task<int> CountAsync();
        Task<IEnumerable<User>> GetUsersPaginatedAsync(int? page, int pageSize);
    }
}
