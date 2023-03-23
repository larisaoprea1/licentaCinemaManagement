using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Genres.Queries.CountGenres
{
    public class CountGenresQueryHandler : IRequestHandler<CountGenresQuery, int>
    {
        private readonly IGenreRepository _genreRepository;
        public CountGenresQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<int> Handle(CountGenresQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.CountAsync();
        }
    }
}
