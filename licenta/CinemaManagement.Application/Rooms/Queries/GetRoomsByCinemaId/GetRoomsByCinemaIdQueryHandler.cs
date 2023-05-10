using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Queries.GetRoomsByCinemaId
{
    public class GetRoomsByCinemaIdQueryHandler : IRequestHandler<GetRoomsByCinemaIdQuery, IEnumerable<Room>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomsByCinemaIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetRoomsByCinemaIdQuery request, CancellationToken cancellationToken)
        {
            return await _roomRepository.GetRoomsByCinema(request.CinemaId);
        }
    }
}
