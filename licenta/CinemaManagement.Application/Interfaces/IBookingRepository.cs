using CinemaManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<int> CountAsync();
        Task<Booking> CreateBookingAsync(Booking booking);
        void DeleteBooking(Booking booking);
        Task<Booking> GetBookingById(Guid id);
        Task<IEnumerable<Booking>> GetBookings();
        Task<IEnumerable<Booking>> GetBookingsBySessionId(Guid sessionId);
        Task<IEnumerable<Booking>> GetUpcomingBookingsByUserId(Guid userId);
        Task SaveAsync();
        Task UpdateRoomAsync(Booking booking);
    }
}
