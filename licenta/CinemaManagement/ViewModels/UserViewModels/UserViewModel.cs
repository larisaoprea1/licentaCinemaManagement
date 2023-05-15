using CinemaManagement.Domain.Models;

namespace CinemaManagement.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageSrc { get; set; }
        public string PhoneNumber { get; set; }
/*       public ICollection<Booking> Bookings { get; set; }*/  
    }
}
