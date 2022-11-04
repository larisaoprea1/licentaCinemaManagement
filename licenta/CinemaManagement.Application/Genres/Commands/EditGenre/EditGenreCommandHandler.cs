using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.EditGenre
{
    public class EditGenreCommandHandler : IRequestHandler<EditGenreCommand, Genre>
    {
        private readonly IGenreRepository _genreRepository;
        public EditGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<Genre> Handle(EditGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Id = request.Id,
                GenreName = request.GenreName
            };
            await _genreRepository.UpdateGenreAsync(genre);
            await _genreRepository.SaveAsync();
            return genre;
        }
    }
}
