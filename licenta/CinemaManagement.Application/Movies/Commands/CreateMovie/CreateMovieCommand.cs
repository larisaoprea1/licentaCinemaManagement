using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public Movie Movie { get; set; }
        public List<Guid>? Actors { get; set; }
        public List<Guid>? Genres { get; set; }
        public List<Guid>? Productions { get; set; }
    }
}
