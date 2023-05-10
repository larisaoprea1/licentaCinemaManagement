using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Queries.GetRoomsByCinemaId
{
    public class GetRoomsByCinemaIdQuery : IRequest<IEnumerable<Room>>
    {
        public Guid CinemaId { get; set; }
    }
}
