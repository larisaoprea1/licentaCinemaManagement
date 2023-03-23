using CinemaManagement.Domain.Models;
using MediatR;


namespace CinemaManagement.Application.Movies.Queries.GetAiringMovies
{
    public class GetAiringMoviesQuery : IRequest<IEnumerable<Movie>>
    {
        public string? SearchString { get; set; }
    }
}
