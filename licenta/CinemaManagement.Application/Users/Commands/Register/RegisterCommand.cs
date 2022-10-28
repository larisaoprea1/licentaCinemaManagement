using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Commands.Register
{
    public class RegisterCommand : IRequest<User>
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
