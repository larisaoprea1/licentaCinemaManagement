using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Room>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            return await _roomRepository.GetRoomAsync(request.Id);
        }
    }
}
