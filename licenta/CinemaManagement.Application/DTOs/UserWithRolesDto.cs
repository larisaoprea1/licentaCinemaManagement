using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.DTOs
{
    public class UserWithRolesDto
    {
        public User User { get; set; }
        public List<string> Roles { get; set; }
    }
}
