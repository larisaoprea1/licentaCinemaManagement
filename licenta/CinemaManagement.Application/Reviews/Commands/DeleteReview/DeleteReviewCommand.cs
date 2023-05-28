
using MediatR;

namespace CinemaManagement.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
