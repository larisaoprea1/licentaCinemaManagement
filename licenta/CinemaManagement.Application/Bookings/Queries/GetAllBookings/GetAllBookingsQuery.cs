using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IRequest<IEnumerable<Booking>>
    {
    }
}
