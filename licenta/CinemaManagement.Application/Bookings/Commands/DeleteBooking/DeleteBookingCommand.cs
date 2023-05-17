using MediatR;

namespace CinemaManagement.Application.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}