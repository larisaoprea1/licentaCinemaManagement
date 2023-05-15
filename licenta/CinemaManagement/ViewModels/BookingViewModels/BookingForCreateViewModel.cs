namespace CinemaManagement.ViewModels.BookingViewModels
{
    public class BookingForCreateViewModel
    {
        public Guid UserId { get; set; }
        public Guid SessionId { get; set; }
        public List<Guid> ReservedSeats { get; set; }

    }
}
