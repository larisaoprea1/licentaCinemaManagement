using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionById
{
    public class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, Session>
    {
        private readonly ISessionRepository _sessionRepository;

        public GetSessionByIdQueryHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository=sessionRepository;
        }

        public async Task<Session> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _sessionRepository.GetSessionAsync(request.Id);
        }
    }
}
