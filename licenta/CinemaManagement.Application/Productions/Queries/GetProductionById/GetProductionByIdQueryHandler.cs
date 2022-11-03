using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Queries.GetProductionById
{
    public class GetProductionByIdQueryHandler : IRequestHandler<GetProductionByIdQuery, Production>
    {
        private readonly IProductionRepository _productionRepository;
        public GetProductionByIdQueryHandler(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<Production> Handle(GetProductionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productionRepository.GetProductionAsync(request.Id);
        }
    }
}
