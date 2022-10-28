using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public SeatRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Seat>> GetSeatsAsync()
        {
            return await _cinemaManagementContext.Seats.ToListAsync();
        }
        public async Task<Seat> GetSeatAsync(Guid seatId)
        {
            return await _cinemaManagementContext.Seats.Where(s => s.Id == seatId).FirstOrDefaultAsync();
        }
        public async Task<Seat> CreateProductionAsync(Seat seat)
        {
            _cinemaManagementContext.Seats.Add(seat);
            return seat;
        }
        public async Task UpdateSeatAsync(Seat seat)
        {
            _cinemaManagementContext.Seats.Update(seat);
        }
        public void DeleteSeat(Seat seat)
        {
            _cinemaManagementContext.Seats.Remove(seat);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
