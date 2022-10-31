namespace CinemaManagement.Domain.Models
{
    public class Actor : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Information { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
