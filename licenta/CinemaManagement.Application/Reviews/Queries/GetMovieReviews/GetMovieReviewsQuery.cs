using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Reviews.Queries.GetMovieReviews
{
    public class GetMovieReviewsQuery : IRequest<IEnumerable<Review>>
    {
        public Guid MovieId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
