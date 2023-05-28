
using MediatR;

namespace CinemaManagement.Application.Users.Commands.RemoveMovieFromWatched
{
    public class RemoveMovieFromWatchedCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
    }
}
