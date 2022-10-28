using CinemaManagement.Domain.Models;

namespace CinemaManagement.ViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageSrc { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
