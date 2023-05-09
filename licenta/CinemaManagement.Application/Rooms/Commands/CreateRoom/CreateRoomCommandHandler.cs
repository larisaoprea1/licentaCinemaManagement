
using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ISeatRepository _seatRepository;
        public CreateRoomCommandHandler(IRoomRepository roomRepository, ISeatRepository seatRepository)
        {
            _roomRepository = roomRepository;
            _seatRepository=seatRepository;
        }
        public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.CreateRoomAsync(request.Room);
            if(request.Seats != null)
            {
                foreach(var seat in request.Seats){ 
                    var seatToCreate = new Seat
                    {
                        RoomId = room.Id,
                        Row = seat.Row,
                        Number = seat.Number,
                    };
                    await _seatRepository.CreateSeatAsync(seatToCreate);
                }
            }

            await _roomRepository.SaveAsync();
            return room;
        }
    }
}
