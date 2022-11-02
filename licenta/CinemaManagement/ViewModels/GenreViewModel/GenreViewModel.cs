using CinemaManagement.Domain.Models;

namespace CinemaManagement.ViewModels.GenreViewModel
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
