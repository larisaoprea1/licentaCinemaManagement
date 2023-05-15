using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class ReservedSeatRepository : IReservedSeatRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public ReservedSeatRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<ReservedSeat>> GetReservedSeatsAsync()
        {
            return await _cinemaManagementContext.ReservedSeats.ToListAsync();
        }
        public async Task<ReservedSeat> GetReservedSeatAsync(Guid seatId)
        {
            return await _cinemaManagementContext.ReservedSeats.Where(s => s.Id == seatId).FirstOrDefaultAsync();
        }
        public async Task<ReservedSeat> CreateReservedSeatAsync(ReservedSeat seat)
        {
            _cinemaManagementContext.ReservedSeats.Add(seat);
            return seat;
        }
        public async Task UpdateReservedSeatAsync(ReservedSeat seat)
        {
            _cinemaManagementContext.ReservedSeats.Update(seat);
        }
        public void DeleteReservedSeat(ReservedSeat seat)
        {
            _cinemaManagementContext.ReservedSeats.Remove(seat);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
