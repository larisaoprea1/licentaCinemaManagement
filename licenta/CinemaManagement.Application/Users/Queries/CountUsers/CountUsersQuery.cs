using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Users.Queries.CountUsers
{
    public class CountUsersQuery : IRequest<int>
    {
    }
}
