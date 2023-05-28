using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Reviews.Queries.GetUsersReviews
{
    public class GetUsersReviewsQuery : IRequest<IEnumerable<Review>>
    {
        public Guid UserId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
