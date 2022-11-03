using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.CreateProduction
{
    public class CreateProductionCommand : IRequest<Production>
    {
        public Production Production { get; set; }
    }
}
