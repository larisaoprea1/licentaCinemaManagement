using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Queries.GetMoviesPaginated
{
    public class GetMoviesPaginatedQuery : IRequest<IEnumerable<Movie>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
    }
}
