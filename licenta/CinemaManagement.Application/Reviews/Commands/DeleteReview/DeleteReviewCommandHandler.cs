using CinemaManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;
        public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.ReturnByIdAsync(request.Id);
            await _reviewRepository.DeleteAsync(review);
            await _reviewRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
