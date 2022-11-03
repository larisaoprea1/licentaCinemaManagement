using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.AddActorToMovie
{
    public class AddActorToMovieCommand : IRequest<Actor>
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
    }
}
