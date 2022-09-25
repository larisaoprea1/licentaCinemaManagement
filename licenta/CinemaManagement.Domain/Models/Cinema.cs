namespace CinemaManagement.Domain.Models
{
    public class Cinema : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
