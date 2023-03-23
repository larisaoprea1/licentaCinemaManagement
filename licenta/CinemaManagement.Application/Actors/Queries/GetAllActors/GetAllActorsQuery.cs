using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Queries.GetAllActors
{
    public class GetAllActorsQuery : IRequest<IEnumerable<Actor>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
