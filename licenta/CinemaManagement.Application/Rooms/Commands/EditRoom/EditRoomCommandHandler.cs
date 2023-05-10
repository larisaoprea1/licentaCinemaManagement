using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Commands.EditRoom
{
    public class EditRoomCommandHandler : IRequestHandler<EditRoomCommand, Room>
    {
        private readonly IRoomRepository _roomRepository;
        public EditRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> Handle(EditRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomAsync(request.Id);

            room.Name = request.Name;
            await _roomRepository.UpdateRoomAsync(room);
            await _roomRepository.SaveAsync();
            return room;
        }
    }
}
