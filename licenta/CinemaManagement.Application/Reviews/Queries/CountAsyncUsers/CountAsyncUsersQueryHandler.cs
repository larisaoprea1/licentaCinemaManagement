using CinemaManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Reviews.Queries.CountAsyncUsers
{
    public class CountAsyncUsersQueryHandler : IRequestHandler<CountAsyncUsersQuery, int>
    {
        private readonly IReviewRepository _reviewRepository;
        public CountAsyncUsersQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository=reviewRepository;
        }

        public async Task<int> Handle(CountAsyncUsersQuery request, CancellationToken cancellationToken)
        {
            var count = await _reviewRepository.CountAsyncUser(request.UserId);
            return count;
        }
    }
}
