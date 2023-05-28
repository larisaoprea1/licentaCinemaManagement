using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Users.Commands.AddMovieToWatched
{
    public class AddMovieToWatchedCommandHandler : IRequestHandler<AddMovieToWatchedCommand, Guid>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public AddMovieToWatchedCommandHandler(IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _movieRepository=movieRepository;
            _userRepository=userRepository;
        }

        public async Task<Guid> Handle(AddMovieToWatchedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserAsync(request.UserId);
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);

            _userRepository.AddMovieToWatched(user, movie);
            await _userRepository.SaveAsync();

            return movie.Id;
        }
    }
}
