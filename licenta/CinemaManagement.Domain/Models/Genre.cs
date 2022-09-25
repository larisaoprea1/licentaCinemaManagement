namespace CinemaManagement.Domain.Models
{
    public class Genre : BaseModel
    {
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
