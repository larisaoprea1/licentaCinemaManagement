using MediatR;

namespace CinemaManagement.Application.Productions.Commands.DeleteProduction
{
    public class DeleteProductionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
