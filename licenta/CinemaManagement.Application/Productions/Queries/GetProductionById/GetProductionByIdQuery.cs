using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Queries.GetProductionById
{
    public class GetProductionByIdQuery : IRequest<Production>
    {
        public Guid Id { get; set; }
    }
}
