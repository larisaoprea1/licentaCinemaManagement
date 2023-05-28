using CinemaManagement.Application.Interfaces;
using MediatR;


namespace CinemaManagement.Application.Users.Commands.RemoveMovieFromWatched
{
    public class RemoveMovieFromWatchedCommandHandler : IRequestHandler<RemoveMovieFromWatchedCommand, Guid>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public RemoveMovieFromWatchedCommandHandler(IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _movieRepository=movieRepository;
            _userRepository=userRepository;
        }

        public async Task<Guid> Handle(RemoveMovieFromWatchedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserId);
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);

            _userRepository.RemoveMovieFromWatched(user, movie);
            await _userRepository.SaveAsync();

            return movie.Id;
        }
    }
}
