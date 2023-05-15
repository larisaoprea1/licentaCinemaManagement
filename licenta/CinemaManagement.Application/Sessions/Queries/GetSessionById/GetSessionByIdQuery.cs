using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionById
{
    public class GetSessionByIdQuery : IRequest<Session>
    {
        public Guid Id { get; set; }
    }
}
