using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Queries.GetAllGenres
{
    public class GetAllGenresQuery :IRequest<IEnumerable<Genre>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
