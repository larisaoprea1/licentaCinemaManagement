using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Reviews.Queries.CountAsyncReviews
{
    public class CountAsyncReviewsQuery : IRequest<int>
    {
        public Guid MovieId { get; set; }
    }
}
