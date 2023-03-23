using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IProductionRepository _productionRepository;
        private readonly IActorRepository _actorRepository;
        public CreateMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IProductionRepository productionRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository=genreRepository;
            _productionRepository=productionRepository;
            _actorRepository=actorRepository;
        }

        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.Movie;

            if (request.Genres != null)
            {
                var genres = await _genreRepository.GetGenresById(request.Genres);
                movie.Genres  = genres;
            }

            if (request.Productions != null)
            {
                var productions = await _productionRepository.GetProductionsById(request.Productions);
                movie.Productions  = productions;
            }

            if(request.Actors != null)
            {
                var actors = await _actorRepository.GetActorsById(request.Actors);
                movie.Actors  = actors;
            }

            var movieToCreate = await _movieRepository.CreateMovieAsync(movie);
            await _movieRepository.SaveAsync();
            return movieToCreate;
        }
    }
}
