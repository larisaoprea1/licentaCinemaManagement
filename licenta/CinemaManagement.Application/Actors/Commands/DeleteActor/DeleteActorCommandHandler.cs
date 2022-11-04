using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.DeleteActor
{
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
    {
        private readonly IActorRepository _actorRepository;
        public DeleteActorCommandHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<Unit> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetActorAsync(request.Id);
            _actorRepository.DeleteActor(actor);
            await _actorRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
