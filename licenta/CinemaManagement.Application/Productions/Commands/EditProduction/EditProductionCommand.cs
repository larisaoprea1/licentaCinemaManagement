using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.EditProduction
{
    public class EditProductionCommand : IRequest<Production>
    {
        public Guid Id { get; set; }
        public string ProductionName { get; set; }
        public string Description { get; set; }
    }
}
