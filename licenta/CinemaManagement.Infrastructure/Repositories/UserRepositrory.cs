using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class UserRepositrory : IUserRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public UserRepositrory(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _cinemaManagementContext.Users
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersPaginatedAsync(int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);
            return await _cinemaManagementContext.Users.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _cinemaManagementContext.Users
                .Where(u => u.Id == userId)
                .Include(x => x.Movies)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetUsersWatchedMovies(string username)
        {
            return await _cinemaManagementContext.Users
                 .Where(x => x.UserName == username)
                 .SelectMany(x => x.Movies)
                 .ToListAsync();
        }
        public void AddMovieToWatched(User user, Movie movie)
        {
            user.Movies.Add(movie);
        }

        public void RemoveMovieFromWatched(User user, Movie movie)
        {
            user.Movies.Remove(movie);
        }
        public async Task UpdateUserAsync(User user)
        {
            _cinemaManagementContext.Users.Update(user);
        }
        public void DeleteUser(User user)
        {
            _cinemaManagementContext.Users.Remove(user);
        }
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Users.CountAsync();
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
