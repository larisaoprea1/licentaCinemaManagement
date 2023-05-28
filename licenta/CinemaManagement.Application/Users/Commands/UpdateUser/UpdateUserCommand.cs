using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageSrc { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
