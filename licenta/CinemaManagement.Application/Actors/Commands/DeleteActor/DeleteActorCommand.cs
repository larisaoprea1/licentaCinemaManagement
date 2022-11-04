using MediatR;

namespace CinemaManagement.Application.Actors.Commands.DeleteActor
{
    public class DeleteActorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
