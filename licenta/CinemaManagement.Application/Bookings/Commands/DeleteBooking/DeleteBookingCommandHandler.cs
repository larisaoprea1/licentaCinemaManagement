using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Bookings.Commands.DeleteBooking
{
    internal class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, string>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IReservedSeatRepository _reservedSeatRepository;
        private readonly ISessionRepository _sessionRepository;

        public DeleteBookingCommandHandler(IBookingRepository bookingRepository, IReservedSeatRepository reservedSeatRepository, ISessionRepository sessionRepository)
        {
            _bookingRepository=bookingRepository;
            _reservedSeatRepository=reservedSeatRepository;
            _sessionRepository=sessionRepository;
        }

        public async Task<string> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingById(request.Id);
            var session = await _sessionRepository.GetSessionAsync(booking.SessionId);

            if (booking.ReservedSeats != null)
            {
                foreach (var reservedSeat in booking.ReservedSeats)
                {

                    _reservedSeatRepository.DeleteReservedSeat(reservedSeat);
                    session.ReservedSeats.Remove(reservedSeat);
                }
            }

            _bookingRepository.DeleteBooking(booking);
            await _bookingRepository.SaveAsync();
            return "Deleted";
        }
    }
}