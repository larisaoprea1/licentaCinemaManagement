using CinemaManagement.Domain.Models;
using MediatR;


namespace CinemaManagement.Application.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<Review>
    {
        public Guid Id { get; set; }
    }
}
