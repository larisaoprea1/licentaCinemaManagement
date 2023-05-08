using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Queries.GetMoviesPaginated
{
    public class GetMoviesPaginatedQueryHandler : IRequestHandler<GetMoviesPaginatedQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesPaginatedQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository=movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesPaginatedQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetMoviesPaginatedAsync(request.Page, request.PageSize, request.SearchString);
        }
    }
}
