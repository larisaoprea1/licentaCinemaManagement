namespace CinemaManagement.Domain.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public bool IsAdult { get; set; }
        public string ImdbLink { get; set; }
        public string TrailerLink { get; set; }
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string RunTime { get; set; }
        public int MovieBudget { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Production> Productions { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
