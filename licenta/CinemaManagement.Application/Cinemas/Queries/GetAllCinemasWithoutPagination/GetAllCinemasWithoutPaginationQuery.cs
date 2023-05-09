using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Queries.GetAllCinemasWithoutPagination
{
    public class GetAllCinemasWithoutPaginationQuery : IRequest<IEnumerable<Cinema>>
    {
    }
}
