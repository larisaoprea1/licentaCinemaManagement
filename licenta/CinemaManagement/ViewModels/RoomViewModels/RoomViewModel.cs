using CinemaManagement.ViewModels.CinemaViewModels;
using CinemaManagement.ViewModels.SeatViewModels;

namespace CinemaManagement.ViewModels.RoomViewModels
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CinemaViewModel Cinema { get; set; }
        public ICollection<SeatViewModel> Seats { get; set; }

    }
}
