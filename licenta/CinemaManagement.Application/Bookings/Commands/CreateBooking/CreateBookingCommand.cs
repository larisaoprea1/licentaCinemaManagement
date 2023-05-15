using CinemaManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<Booking>
    {
        public Booking Booking { get; set; }
        public ICollection<Guid> ReservedSeats { get; set; }
    }
}
