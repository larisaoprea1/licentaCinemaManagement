using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public Guid Id { get; set; }
    }
}
