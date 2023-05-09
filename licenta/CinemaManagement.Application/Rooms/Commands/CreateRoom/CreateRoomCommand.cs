using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<Room>
    {
        public Room Room { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
