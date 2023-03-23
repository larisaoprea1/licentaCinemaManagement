using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Queries.GetAllGenresWithoutPagination
{
    public class GetAllGenresWithoutPaginationQuery : IRequest<IEnumerable<Genre>>
    {
    }
}
