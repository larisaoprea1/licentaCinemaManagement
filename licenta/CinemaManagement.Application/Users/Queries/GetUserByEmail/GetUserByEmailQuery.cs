using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}
