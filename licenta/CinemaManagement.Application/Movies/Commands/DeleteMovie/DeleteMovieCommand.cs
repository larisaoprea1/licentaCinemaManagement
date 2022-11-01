using MediatR;

namespace CinemaManagement.Application.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
