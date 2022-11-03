using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Queries.GetActorsById
{
    public class GetActorByIdQuery : IRequest<Actor>
    {
        public Guid Id { get; set; }
    }
}
