using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Reviews.Queries.GetMovieReviews
{
    public class GetMovieReviewsQueryHandler : IRequestHandler<GetMovieReviewsQuery, IEnumerable<Review>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;
        public GetMovieReviewsQueryHandler(IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository=movieRepository;
        }
        public async Task<IEnumerable<Review>> Handle(GetMovieReviewsQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);
            var reviews = await _reviewRepository.ReturnMovieReviews(movie, request.Page, request.PageSize);

            return reviews;
        }
    }
}
