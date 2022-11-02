using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IGenreRepository _genreRepository;
        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.CreateGenreAsync(request.Genre);
            await _genreRepository.SaveAsync();
            return genre;
        }
    }
}
