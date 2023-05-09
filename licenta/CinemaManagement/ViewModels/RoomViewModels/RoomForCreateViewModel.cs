using CinemaManagement.ViewModels.SeatViewModels;

namespace CinemaManagement.ViewModels.RoomViewModels
{
    public class RoomForCreateViewModel
    {
        public string Name { get; set; }
        public List<SeatViewModel> Seats { get; set; }
        public Guid CinemaId { get; set; }
    }
}
