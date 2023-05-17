using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionsByRoomId
{
    public class GetSessionByRoomIdQuery : IRequest<IEnumerable<Session>>
    {
        public Guid RoomId { get; set; }
    }
}
