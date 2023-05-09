namespace CinemaManagement.Domain.Models
{
    public class Seat : BaseModel
    {
        public string Row { get; set; }
        public int Number { get; set; } 
        public Room Room{ get; set; }
        public Guid RoomId { get; set; }
        public ICollection<ReservedSeat> ReservedSeats { get; set; }
        
    }
}