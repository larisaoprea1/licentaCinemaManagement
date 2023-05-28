using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Reviews.Queries.CountAsyncUsers
{
    public class CountAsyncUsersQuery : IRequest<int>
    {
        public Guid UserId { get; set; }
    }
}
