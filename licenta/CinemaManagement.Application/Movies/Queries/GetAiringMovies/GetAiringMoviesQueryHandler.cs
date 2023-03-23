using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Queries.GetAiringMovies
{
    public class GetAiringMoviesQueryHandler : IRequestHandler<GetAiringMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetAiringMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<Movie>> Handle(GetAiringMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetAiringMovies(request.SearchString);
        }
    }
}
