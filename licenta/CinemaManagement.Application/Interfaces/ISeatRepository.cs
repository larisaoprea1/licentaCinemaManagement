using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeatsAsync();
        Task<Seat> GetSeatAsync(Guid seatId);
        Task<Seat> CreateProductionAsync(Seat seat);
        Task UpdateSeatAsync(Seat seat);
        void DeleteSeat(Seat seat);
        Task SaveAsync();
    }
}
