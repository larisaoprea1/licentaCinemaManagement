using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.AddActorToMovie
{
    public class AddActorToMovieCommandHandler : IRequestHandler<AddActorToMovieCommand, Actor>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMovieRepository _movieRepository; 
        public AddActorToMovieCommandHandler(IActorRepository actorRepository, IMovieRepository movieRepository)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Actor> Handle(AddActorToMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);
            var actor = await _actorRepository.GetActorAsync(request.ActorId);
            await _actorRepository.AddActorToMovieAsync(movie, actor);
            await _actorRepository.SaveAsync();
            return actor;
        }
    }
}
