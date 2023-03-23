using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Actors.Queries.GetAllActors
{
    public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, IEnumerable<Actor>>
    {
        private readonly IActorRepository _actorRepository;
        public GetAllActorsQueryHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IEnumerable<Actor>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.GetActorsAsync(request.Page, request.PageSize);
        }
    }
}
