using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;


namespace CinemaManagement.Application.Productions.Queries.GetAllProductionsWithoutPagination.cs
{
    public class GetAllProductionsWithoutPaginationQueryHandler : IRequestHandler<GetAllProductionsWithoutPaginationQuery, IEnumerable<Production>>
    {
        private readonly IProductionRepository _productionRepository;
        public GetAllProductionsWithoutPaginationQueryHandler(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<IEnumerable<Production>> Handle(GetAllProductionsWithoutPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _productionRepository.GetProductionsWithoutPagination();
        }
    }
}
