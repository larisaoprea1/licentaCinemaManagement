using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Queries.GetAllRoomsWithoutPagination
{
    public class GetAllRoomsWithoutPaginationQueryHandler : IRequestHandler<GetAllRoomsWithoutPaginationQuery, IEnumerable<Room>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetAllRoomsWithoutPaginationQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> Handle(GetAllRoomsWithoutPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _roomRepository.GetRoomsWithoutPagination();
        }
    }
}
