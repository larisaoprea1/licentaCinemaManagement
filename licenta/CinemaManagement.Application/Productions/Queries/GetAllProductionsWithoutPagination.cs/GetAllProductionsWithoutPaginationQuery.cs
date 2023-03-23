using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Queries.GetAllProductionsWithoutPagination.cs
{
    public class GetAllProductionsWithoutPaginationQuery : IRequest<IEnumerable<Production>>
    {
    }
}
