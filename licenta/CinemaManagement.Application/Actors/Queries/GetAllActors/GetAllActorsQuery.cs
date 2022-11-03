using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Queries.GetAllActors
{
    public class GetAllActorsQuery : IRequest<IEnumerable<Actor>>
    {
    }
}
