using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.ReturnByIdAsync(request.Id);
        }
    }
}
