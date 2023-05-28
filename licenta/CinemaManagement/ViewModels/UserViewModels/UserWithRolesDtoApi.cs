using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.UserViewModels;

namespace CinemaManagement.Application.DTOs
{
    public class UserWithRolesDtoApi
    {
        public UserViewModel User { get; set; }
        public List<string> Roles { get; set; }
    }
}
