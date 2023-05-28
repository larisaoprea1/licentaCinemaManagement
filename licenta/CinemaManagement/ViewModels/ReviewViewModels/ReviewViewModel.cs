using CinemaManagement.ViewModels.MovieViewModels;
using CinemaManagement.ViewModels.UserViewModels;

namespace CinemaManagement.ViewModels.ReviewViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public UserViewModel User { get; set; }
        public MovieViewModel Movie { get; set; }
        public double Rating { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
