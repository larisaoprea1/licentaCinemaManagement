namespace CinemaManagement.Domain.Models
{
    public class Session :BaseModel
    {
        public DateTime SessionStart { get; set; }  
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        public Room Room { get; set; }  
        public Guid RoomId { get; set; }
        public ICollection<ReservedSeat> ReservedSeats { get; set; }
    }
}