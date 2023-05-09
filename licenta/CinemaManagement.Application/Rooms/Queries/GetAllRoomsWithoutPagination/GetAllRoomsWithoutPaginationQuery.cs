using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Rooms.Queries.GetAllRoomsWithoutPagination
{
    public class GetAllRoomsWithoutPaginationQuery : IRequest<IEnumerable<Room>>
    {
    }
}
