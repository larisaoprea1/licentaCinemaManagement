using MediatR;


namespace CinemaManagement.Application.Users.Commands.AddMovieToWatched
{
    public class AddMovieToWatchedCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
    }
}
