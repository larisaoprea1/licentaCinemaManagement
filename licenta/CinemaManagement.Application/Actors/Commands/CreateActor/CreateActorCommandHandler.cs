using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Actor>
    {
        private readonly IActorRepository _actorRepository;
        public CreateActorCommandHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public async Task<Actor> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.CreateActorAsync(request.Actor);
            await _actorRepository.SaveAsync();
            return actor;
        }
    }
}
