using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;
        public DeleteGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenreAsync(request.Id);
            _genreRepository.DeleteGenre(genre);
            await _genreRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
