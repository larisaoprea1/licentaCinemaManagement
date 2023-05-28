using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.Domain.Models
{
    public class Review : BaseModel
    {
        public string Content { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }
    }
}
