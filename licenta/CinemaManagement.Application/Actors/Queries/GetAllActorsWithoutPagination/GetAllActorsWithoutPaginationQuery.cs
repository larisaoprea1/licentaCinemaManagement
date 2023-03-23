using CinemaManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Actors.Queries.GetAllActorsWithoutPagination
{
    public class GetAllActorsWithoutPaginationQuery : IRequest<IEnumerable<Actor>>
    {
    }
}
