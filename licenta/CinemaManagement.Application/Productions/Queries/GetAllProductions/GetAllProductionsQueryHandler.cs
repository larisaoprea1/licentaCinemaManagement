using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Queries.GetAllProductions
{
    public class GetAllProductionsQueryHandler : IRequestHandler<GetAllProductionsQuery, IEnumerable<Production>>
    {
        private readonly IProductionRepository _productionRepository;
        public GetAllProductionsQueryHandler(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<IEnumerable<Production>> Handle(GetAllProductionsQuery request, CancellationToken cancellationToken)
        {
            return await _productionRepository.GetProductionsAsync(request.Page, request.PageSize);
        }
    }
}
