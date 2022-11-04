using MediatR;

namespace CinemaManagement.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
