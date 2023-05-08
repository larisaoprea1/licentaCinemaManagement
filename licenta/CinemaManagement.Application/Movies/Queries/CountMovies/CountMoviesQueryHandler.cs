
using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Movies.Queries.CountMovies
{
    public class CountMoviesQueryHandler : IRequestHandler<CountMoviesQuery, int>
    {
        private readonly IMovieRepository _movieRepository;

        public CountMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository=movieRepository;
        }

        public async Task<int> Handle(CountMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.CountAsync(request.SearchString);
        }
    }
}
