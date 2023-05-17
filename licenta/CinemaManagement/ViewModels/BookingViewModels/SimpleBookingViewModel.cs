using CinemaManagement.ViewModels.ReservedSeatViewModels;
using CinemaManagement.ViewModels.SessionViewModels;

namespace CinemaManagement.ViewModels.BookingViewModels
{
    public class SimpleBookingViewModel
    {
        public Guid Id { get; set; }
        public SimpleSessionViewModel Session { get; set; }
        public List<ReservedSeatViewModel> ReservedSeats { get; set; }
    }
}
