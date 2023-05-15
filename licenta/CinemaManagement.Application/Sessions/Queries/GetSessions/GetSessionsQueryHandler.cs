using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessions
{
    public class GetSessionsQueryHandler : IRequestHandler<GetSessionsQuery, IEnumerable<Session>>
    {
        private readonly ISessionRepository _sessionRepository;

        public GetSessionsQueryHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository=sessionRepository;
        }

        public async Task<IEnumerable<Session>> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
        {
            return await _sessionRepository.GetSessions();
        }
    }
}
