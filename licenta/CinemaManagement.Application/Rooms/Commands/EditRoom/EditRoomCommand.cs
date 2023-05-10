using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Commands.EditRoom
{
    public class EditRoomCommand : IRequest<Room>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
