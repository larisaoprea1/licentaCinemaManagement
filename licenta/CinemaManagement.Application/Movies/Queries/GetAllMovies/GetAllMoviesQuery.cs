using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Queries.GetAllMovies
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {
        public string? SearchString { get; set; }
    }
}
