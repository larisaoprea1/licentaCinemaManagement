using CinemaManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Interfaces
{
    public interface IReservedSeatRepository
    {
        Task<ReservedSeat> CreateReservedSeatAsync(ReservedSeat seat);
        void DeleteReservedSeat(ReservedSeat seat);
        Task<ReservedSeat> GetReservedSeatAsync(Guid seatId);
        Task<IEnumerable<ReservedSeat>> GetReservedSeatsAsync();
        Task SaveAsync();
        Task UpdateReservedSeatAsync(ReservedSeat seat);
    }
}
