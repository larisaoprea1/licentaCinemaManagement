using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.EditGenre
{
    public class EditGenreCommand : IRequest<Genre>
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
    }
}
