namespace CinemaManagement.Domain.Models
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public Guid CinemaId { get; set; }  
        public Cinema Cinema { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}