using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _cinemaManagementContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }
        public void DeleteUser(User user)
        {
            _cinemaManagementContext.Users.Remove(user);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
