namespace CinemaManagement.Domain.Models
{
    public class Movie:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAdult { get; set; }
        public string ImdbLink { get; set; }
        public string TrailerLink { get; set; }
        public string Poster { get; set; }
        public DateTime ReleaseDate { get; set; }  
        public TimeSpan RunTime { get; set; }
        public int MovieBudget { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Genre> Genres { get; set; }

        public ICollection<Production> Productions { get; set; }
    }
}
