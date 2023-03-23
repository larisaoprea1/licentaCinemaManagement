using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Actors.Queries.GetAllActorsWithoutPagination
{
    public class GetAllActorsWithoutPaginationQueryHandler : IRequestHandler<GetAllActorsWithoutPaginationQuery, IEnumerable<Actor>>
    {
        private readonly IActorRepository _actorRepository;
        public GetAllActorsWithoutPaginationQueryHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IEnumerable<Actor>> Handle(GetAllActorsWithoutPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.GetActorsWithoutPagination();
        }
    }
}
