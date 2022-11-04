using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Commands.EditActor
{
    public class EditActorCommandHandler : IRequestHandler<EditActorCommand, Actor>
    {
        private readonly IActorRepository _actorRepository;
        public EditActorCommandHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public async Task<Actor> Handle(EditActorCommand request, CancellationToken cancellationToken)
        {

            var actorToEdit = new Actor
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Information = request.Information,
                Nationality = request.Nationality,
                BirthDay = request.BirthDay,
                PictureSrc = request.PictureSrc
            };
            await _actorRepository.UpdateActorAsync(actorToEdit);
            await _actorRepository.SaveAsync();
            return actorToEdit;

        }
    }
}
