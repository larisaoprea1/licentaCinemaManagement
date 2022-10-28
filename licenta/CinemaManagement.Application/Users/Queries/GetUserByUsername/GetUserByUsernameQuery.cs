using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string UserName { get; set; }
    }
}
