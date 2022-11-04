using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.EditProduction
{
    public class EditProductionCommandHandler : IRequestHandler<EditProductionCommand, Production>
    {
        private readonly IProductionRepository _productionRepository;
        public EditProductionCommandHandler(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }
        public async Task<Production> Handle(EditProductionCommand request, CancellationToken cancellationToken)
        {
            var productionToEdit = new Production
            {
                Id = request.Id,
                ProductionName = request.ProductionName,
                Description = request.Description,
            };
            await _productionRepository.UpdateProductionAsync(productionToEdit);
            await _productionRepository.SaveAsync();
            return productionToEdit;
        }
    }
}
