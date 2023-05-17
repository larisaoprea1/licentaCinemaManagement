
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Bookings.Queries.GetUpcomingBookingsByUserId
{
    public class GetUpcomingBookingsByUserIdQuery : IRequest<IEnumerable<Booking>>
    {
        public Guid UserId { get; set; }
    }
}
