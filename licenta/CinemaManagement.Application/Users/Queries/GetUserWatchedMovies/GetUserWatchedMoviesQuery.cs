using CinemaManagement.Domain.Models;
using MediatR;


namespace CinemaManagement.Application.Users.Queries.GetUserWatchedMovies
{
    public class GetUserWatchedMoviesQuery : IRequest<IEnumerable<Movie>>
    {
        public string UserName { get; set; }
    }
}
