using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomAsync(request.Id);
            _roomRepository.DeleteRoom(room);
            await _roomRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
