using CinemaManagement.ViewModels.RoomViewModels;

namespace CinemaManagement.ViewModels.CinemaViewModels
{
    public class CinemaViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

    }
}
