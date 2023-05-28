using CinemaManagement.Application.DTOs;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Users.Queries.GetUsersPaginated
{
    public class GetUsersPaginatedQuery : IRequest<IEnumerable<UserWithRolesDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
