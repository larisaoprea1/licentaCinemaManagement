namespace CinemaManagement.ViewModels.ReviewViewModels
{
    public class ReviewToCreateViewModel
    {
        public string Content { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public double Rating { get; set; }
    }
}
