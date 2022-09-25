namespace CinemaManagement.Domain.Models
{
    public class Production: BaseModel
    {
        public string ProductionName { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}