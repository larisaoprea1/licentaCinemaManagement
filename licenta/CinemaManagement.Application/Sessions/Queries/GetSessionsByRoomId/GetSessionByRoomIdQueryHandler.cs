using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionsByRoomId
{
    internal class GetSessionByRoomIdQueryHandler : IRequestHandler<GetSessionByRoomIdQuery, IEnumerable<Session>>
    {
        private readonly ISessionRepository _sessionRepository;

        public GetSessionByRoomIdQueryHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository=sessionRepository;
        }
        public async Task<IEnumerable<Session>> Handle(GetSessionByRoomIdQuery request, CancellationToken cancellationToken)
        {
            return await _sessionRepository.GetSessionsByRoom(request.RoomId);
        }
    }
}
