using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Bookings.Queries.GetUpcomingBookingsByUserId
{
    public class GetUpcomingBookingsByUserIdQueryHandler : IRequestHandler<GetUpcomingBookingsByUserIdQuery, IEnumerable<Booking>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetUpcomingBookingsByUserIdQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository=bookingRepository;
        }

        public async Task<IEnumerable<Booking>> Handle(GetUpcomingBookingsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetUpcomingBookingsByUserId(request.UserId);
        }
    }
}
