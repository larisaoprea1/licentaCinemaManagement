using MediatR;

namespace CinemaManagement.Application.Movies.Queries.CountMovies
{
    public class CountMoviesQuery : IRequest<int>
    {
        public string SearchString { get; set; }
    }
}
