using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public BookingRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _cinemaManagementContext.Bookings
               .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
               .Include(u => u.User)
               .Include(s => s.Session)
               .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsBySessionId(Guid sessionId)
        {
            return await _cinemaManagementContext.Bookings
               .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
               .Include(u => u.User)
               .Include(s => s.Session)
               .Where(r => r.SessionId == sessionId)
               .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetUpcomingBookingsByUserId(Guid userId)
        {
            return await _cinemaManagementContext.Bookings
               .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
               .Include(u => u.User)
               .Include(s => s.Session).ThenInclude(r => r.Room)
               .Include(s => s.Session).ThenInclude(r => r.Movie)
               .Where(r => r.UserId == userId && r.Session.SessionStart >= DateTime.UtcNow)
               .ToListAsync();
        }

        public async Task<Booking> GetBookingById(Guid id)
        {
            return await _cinemaManagementContext.Bookings
               .Include(r => r.ReservedSeats).ThenInclude(s => s.Seat)
               .Include(u => u.User)
               .Include(s => s.Session).ThenInclude(r => r.Room)
               .Include(s => s.Session).ThenInclude(r => r.Movie)
               .Where(r => r.Id == id)
               .FirstOrDefaultAsync();
        }
        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _cinemaManagementContext.Bookings.Add(booking);
            return booking;
        }
        public async Task UpdateRoomAsync(Booking booking)
        {
            _cinemaManagementContext.Bookings.Update(booking);
        }
        public void DeleteBooking(Booking booking)
        {
            _cinemaManagementContext.Bookings.Remove(booking);
        }
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Bookings.CountAsync();
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
