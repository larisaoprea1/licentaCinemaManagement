using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionForMovieByCinema
{
    public class GetSessionForMovieByCinemaQueryHandler : IRequestHandler<GetSessionForMovieByCinemaQuery, IEnumerable<Session>>
    {

        private readonly ISessionRepository _sessionRepository;

        public GetSessionForMovieByCinemaQueryHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository=sessionRepository;
        }
        public async Task<IEnumerable<Session>> Handle(GetSessionForMovieByCinemaQuery request, CancellationToken cancellationToken)
        {
            return await _sessionRepository.GetSessionByMovieAndCinema(request.MovieId, request.CinemaId);
        }
    }
}
