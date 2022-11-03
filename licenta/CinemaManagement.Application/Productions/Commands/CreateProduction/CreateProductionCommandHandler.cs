using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.CreateProduction
{
    public class CreateProductionCommandHandler : IRequestHandler<CreateProductionCommand, Production>
    {
        private readonly IProductionRepository _productionRepository;
        public CreateProductionCommandHandler(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }
        public async Task<Production> Handle(CreateProductionCommand request, CancellationToken cancellationToken)
        {
            var production = await _productionRepository.CreateProductionAsync(request.Production);
            await _productionRepository.SaveAsync();
            return production;
        }
    }
}
