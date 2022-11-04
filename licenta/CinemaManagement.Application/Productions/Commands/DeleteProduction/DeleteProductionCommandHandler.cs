using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.DeleteProduction
{
    public class DeleteProductionCommandHandler : IRequestHandler<DeleteProductionCommand>
    {
        private readonly IProductionRepository _productionRepository;
        public DeleteProductionCommandHandler(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<Unit> Handle(DeleteProductionCommand request, CancellationToken cancellationToken)
        {
            var production = await _productionRepository.GetProductionAsync(request.Id);
            _productionRepository.DeleteProduction(production);
            await _productionRepository.SaveAsync();
            return Unit.Value;

        }
    }
}
