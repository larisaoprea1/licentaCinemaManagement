using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Bookings.Queries.GetBooking
{
    public class GetBookingQuery : IRequest<Booking>
    {
        public Guid Id { get; set; }
    }
}
