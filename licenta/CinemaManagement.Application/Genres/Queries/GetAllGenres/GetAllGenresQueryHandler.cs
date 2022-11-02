using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Queries.GetAllGenres
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _genreRepository;
        public GetAllGenresQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<Genre>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetGenresAsync();
        }
    }
}
