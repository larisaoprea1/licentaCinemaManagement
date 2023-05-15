using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessions
{
    public class GetSessionsQuery : IRequest<IEnumerable<Session>>
    {
    }
}
