using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.AddGenreToMovie
{
    public class AddGenreToMovieCommand : IRequest<Genre>
    {
        public Guid GenreId { get; set; }
        public Guid MovieId { get; set; }
    }
}
