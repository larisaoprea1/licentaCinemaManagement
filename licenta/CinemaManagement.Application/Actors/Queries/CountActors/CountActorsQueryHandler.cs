using CinemaManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Actors.Queries.CountActors
{
    internal class CountActorsQueryHandler : IRequestHandler<CountActorsQuery, int>
    {
        private readonly IActorRepository _actorRepository;
        public CountActorsQueryHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public async Task<int> Handle(CountActorsQuery request, CancellationToken cancellationToken)
        {
            return await _actorRepository.CountAsync();
        }
    }
}
