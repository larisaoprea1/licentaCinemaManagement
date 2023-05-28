using CinemaManagement.Domain.Models;
using MediatR;


namespace CinemaManagement.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public Review Review { get; set; }
    }
}
