using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
