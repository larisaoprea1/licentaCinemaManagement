using AutoMapper;
using CinemaManagement.Application.Bookings.Commands.CreateBooking;
using CinemaManagement.Application.Bookings.Queries.GetAllBookings;
using CinemaManagement.Application.Bookings.Queries.GetBooking;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.BookingViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public BookingController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("bookings")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            var result = _mapper.Map<IEnumerable<BookingViewModel>>(bookings);
            return Ok(result);
        }

        [HttpGet]
        [Route("booking/{bookingId}")]
        public async Task<IActionResult> GetBooking([FromRoute] Guid bookingId)
        {
            var result = await _mediator.Send(new GetBookingQuery
            {
                Id = bookingId
            });
            var mappedResult = _mapper.Map<BookingViewModel>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("createbooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingForCreateViewModel booking)
        {
            var bookingToCreate = new Booking
            {
                SessionId = booking.SessionId,
                UserId = booking.UserId
            };

            var result = await _mediator.Send(new CreateBookingCommand
            {
                Booking = bookingToCreate,
                ReservedSeats = booking.ReservedSeats
            });

            var mappedResult = _mapper.Map<BookingViewModel>(result);

            return Ok(mappedResult);
        }
    }
}
