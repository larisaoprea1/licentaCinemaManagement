using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Queries.GetAllProductions
{
    public class GetAllProductionsQuery : IRequest<IEnumerable<Production>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
