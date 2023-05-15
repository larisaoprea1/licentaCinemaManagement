using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Sessions.Queries.GetSessionForMovieByCinema
{
    public class GetSessionForMovieByCinemaQuery : IRequest<IEnumerable<Session>>
    {
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
    }
}
