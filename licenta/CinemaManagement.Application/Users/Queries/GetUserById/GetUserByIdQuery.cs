using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
