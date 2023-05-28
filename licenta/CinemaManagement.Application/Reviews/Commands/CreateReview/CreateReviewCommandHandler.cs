using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;
        public CreateReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.CreateAsync(request.Review);
            await _reviewRepository.SaveAsync();
            return review;
        }
    }
}
