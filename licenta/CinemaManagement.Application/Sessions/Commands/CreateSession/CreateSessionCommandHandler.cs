

using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, string>
    {
        private readonly ISessionRepository _sessionRepository;

        public CreateSessionCommandHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository=sessionRepository;
        }

        public async Task<string> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            var sessions = await _sessionRepository.CheckForSessionOverlap(request.Session);

            if (sessions.Any())
            {
                return "overlap";
            }

            await _sessionRepository.CreateSessionAsyc(request.Session);
            await _sessionRepository.SaveAsync();
            
            return "Session Created";
        }
    }
}
