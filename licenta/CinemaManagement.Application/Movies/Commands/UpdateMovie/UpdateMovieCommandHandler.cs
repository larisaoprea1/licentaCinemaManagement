using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Movie>
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieToUpdate = new Movie
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Director = request.Director,
                Format = request.Format,
                IsAdult = request.IsAdult,
                ImdbLink = request.ImdbLink,
                TrailerLink = request.TrailerLink,
                Poster = request.Poster,
                ReleaseDate = request.ReleaseDate,
                RunTime = request.RunTime,
                MovieBudget = request.MovieBudget,
            };
             await _movieRepository.UpdateMovieAsync(movieToUpdate);
            await _movieRepository.SaveAsync();
            return movieToUpdate;
        }
    }
}
