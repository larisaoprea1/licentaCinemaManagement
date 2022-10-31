using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<Movie>
    {
        public Movie Movie { get; set; }
    }
}
