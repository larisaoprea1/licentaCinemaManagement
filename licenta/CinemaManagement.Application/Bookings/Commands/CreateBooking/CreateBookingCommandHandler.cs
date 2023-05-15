using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IReservedSeatRepository _reservedSeatRepository;
        private readonly ISessionRepository _sessionRepository;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IReservedSeatRepository reservedSeatRepository, ISessionRepository sessionRepository)
        {
            _bookingRepository=bookingRepository;
            _reservedSeatRepository=reservedSeatRepository;
            _sessionRepository=sessionRepository;
        }

        public async Task<Booking> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
           var session = await _sessionRepository.GetSessionAsync(request.Booking.SessionId);
           var booking = await _bookingRepository.CreateBookingAsync(request.Booking);

            booking.ReservedSeats = new List<ReservedSeat>();

            if(request.ReservedSeats != null)
            {
                foreach(var reservedSeat in request.ReservedSeats)
                {
                    var rSeat = new ReservedSeat
                    {
                        BookingId = booking.Id,
                        SeatId = reservedSeat,
                        SessionId = booking.SessionId,
                    };
                    await _reservedSeatRepository.CreateReservedSeatAsync(rSeat);

                    booking.ReservedSeats.Add(rSeat);
                    session.ReservedSeats.Add(rSeat);
                }
            }
            await _sessionRepository.SaveAsync();
            return booking;
        }
    }
}
