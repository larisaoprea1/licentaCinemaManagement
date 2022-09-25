namespace CinemaManagement.Domain.Models
{
    public class Booking : BaseModel
    {
        public ICollection<ReservedSeat> ReservedSeats { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Session Session { get; set; }
        public Guid SessionId { get; set; }
    }
}