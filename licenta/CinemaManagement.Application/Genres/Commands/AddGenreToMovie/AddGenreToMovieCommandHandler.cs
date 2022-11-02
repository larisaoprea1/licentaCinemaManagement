using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.AddGenreToMovie
{
    public class AddGenreToMovieCommandHandler:IRequestHandler<AddGenreToMovieCommand, Genre>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _movieRepository;
        public AddGenreToMovieCommandHandler(IGenreRepository genreRepository, IMovieRepository movieRepository)
        {
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Genre> Handle(AddGenreToMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);
            var genre = await _genreRepository.GetGenreAsync(request.GenreId);
            await _genreRepository.AddGenreToMovieAsync(movie, genre);
            await _genreRepository.SaveAsync();
            return genre;
        }
    }
}
