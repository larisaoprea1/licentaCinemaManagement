using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Queries.GetActorsById
{
    public class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly IActorRepository _actorRepository;
        public GetActorByIdQueryHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.GetActorAsync(request.Id);
        }
    }
}
