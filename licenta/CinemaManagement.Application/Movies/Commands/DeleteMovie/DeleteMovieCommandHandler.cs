using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieAsync(request.Id);
            _movieRepository.DeleteMovie(movie);
            await _movieRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
