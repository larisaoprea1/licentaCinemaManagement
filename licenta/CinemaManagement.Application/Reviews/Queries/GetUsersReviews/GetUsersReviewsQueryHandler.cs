using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Reviews.Queries.GetUsersReviews
{
 
    public class GetUsersReviewsQueryHandler : IRequestHandler<GetUsersReviewsQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetUsersReviewsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> Handle(GetUsersReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewRepository.ReturnUserReviews(request.UserId, request.Page, request.PageSize);
            return reviews;
        }
    }
}
