namespace CinemaManagement.Domain.Models
{
    public class ReservedSeat : Entity
    {
        public Seat Seat { get; set; }
        public Guid? SeatId { get; set; }
        public Booking Booking { get; set; }
        public Guid BookingId { get; set; }
        public Session Session { get; set; }
        public Guid? SessionId { get; set; }

    }
}
