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
        void DeleteRoom(Booking booking);
        Task<Booking> GetBookingById(Guid id);
        Task<IEnumerable<Booking>> GetBookings();
        Task<IEnumerable<Booking>> GetBookingsBySessionId(Guid sessionId);
        Task SaveAsync();
        Task UpdateRoomAsync(Booking booking);
    }
}
