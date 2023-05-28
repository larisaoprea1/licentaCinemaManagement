using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CinemaManagement.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageSrc { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
