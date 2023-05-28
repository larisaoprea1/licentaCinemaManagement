using CinemaManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Reviews.Queries.CountAsyncReviews
{
    internal class CountAsyncReviewsQueryHandler : IRequestHandler<CountAsyncReviewsQuery, int>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;
        public CountAsyncReviewsQueryHandler(IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository=movieRepository;
        }

        public async Task<int> Handle(CountAsyncReviewsQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);
            var count = await _reviewRepository.CountAsync(movie);
            return count;
        }
    }
}
