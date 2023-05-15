using CinemaManagement.ViewModels.SeatViewModels;

namespace CinemaManagement.ViewModels.ReservedSeatViewModels
{
    public class ReservedSeatViewModel
    {
        public Guid Id { get; set; }
        public SeatViewModel Seat { get; set; }
    }
}
