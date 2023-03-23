using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Productions.Queries.CountProductionsQuery.cs
{
    public class CountProductionsQueryHandler : IRequestHandler<CountProductionsQuery, int>
    {
        private readonly IProductionRepository _productionRepository;

        public CountProductionsQueryHandler(IProductionRepository productionRepository)
        {
            _productionRepository=productionRepository;
        }

        public async Task<int> Handle(CountProductionsQuery request, CancellationToken cancellationToken)
        {
            return await _productionRepository.CountAsync();
        }
    }
}
