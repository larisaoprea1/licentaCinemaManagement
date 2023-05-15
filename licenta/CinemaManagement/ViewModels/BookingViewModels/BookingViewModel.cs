using CinemaManagement.ViewModels.ReservedSeatViewModels;
using CinemaManagement.ViewModels.SessionViewModels;
using CinemaManagement.ViewModels.UserViewModels;

namespace CinemaManagement.ViewModels.BookingViewModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public UserViewModel User { get; set; }
        public SessionViewModel Session { get; set; }
        public List<ReservedSeatViewModel> ReservedSeats { get; set; }
    }
}
