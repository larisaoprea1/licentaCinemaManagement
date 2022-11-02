using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public Genre Genre { get; set; }    
    }
}
