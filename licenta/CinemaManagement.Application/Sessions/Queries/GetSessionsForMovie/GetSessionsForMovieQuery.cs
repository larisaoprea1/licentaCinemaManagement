
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionsForMovie
{
    public class GetSessionsForMovieQuery : IRequest<IEnumerable<Session>>
    {
        public Guid MovieId { get; set; }
    }
}
