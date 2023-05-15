
using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionsForMovie
{
    public class GetSessionsForMovieQueryHandler : IRequestHandler<GetSessionsForMovieQuery, IEnumerable<Session>>
    {
        private readonly ISessionRepository _sessionRepository;

        public GetSessionsForMovieQueryHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository=sessionRepository;
        }

        public async Task<IEnumerable<Session>> Handle(GetSessionsForMovieQuery request, CancellationToken cancellationToken)
        {
            return await _sessionRepository.GetSessionsByMovie(request.MovieId);
        }
    }
}
