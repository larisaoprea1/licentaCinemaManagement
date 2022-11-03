using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.CreateActor
{
    public class CreateActorCommand :IRequest<Actor>
    {
        public Actor Actor { get; set; }
    }
}
