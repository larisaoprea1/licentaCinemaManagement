using AutoMapper;
using CinemaManagement.Application.Reviews.Commands.CreateReview;
using CinemaManagement.Application.Reviews.Commands.DeleteReview;
using CinemaManagement.Application.Reviews.Queries.CountAsyncReviews;
using CinemaManagement.Application.Reviews.Queries.CountAsyncUsers;
using CinemaManagement.Application.Reviews.Queries.GetMovieReviews;
using CinemaManagement.Application.Reviews.Queries.GetReviewById;
using CinemaManagement.Application.Reviews.Queries.GetUsersReviews;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ReviewViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ReviewController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetReviewByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ReviewViewModel>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("movie/{movieid}/page/{page}/pagesize/{pagesize}")]
        public async Task<IActionResult> GetMovieReviews(Guid movieid, int page, int pagesize)
        {
            var result = await _mediator.Send(new GetMovieReviewsQuery
            {
                MovieId = movieid,
                Page = page,
                PageSize = pagesize
            });

            var count = await _mediator.Send(new CountAsyncReviewsQuery { MovieId=movieid });
            var totalPages = ((double)count / (double)pagesize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var mappedResult = _mapper.Map<IEnumerable<ReviewViewModel>>(result);
            return Ok(new PagedResponse<IEnumerable<ReviewViewModel>>(mappedResult, page, count, roundedTotalPages, pagesize));
        }

        [HttpGet]
        [Route("user/{userId}/page/{page}/pagesize/{pagesize}")]
        public async Task<IActionResult> GetUserReviews(Guid userId, int page, int pagesize)
        {
            var result = await _mediator.Send(new GetUsersReviewsQuery
            {
                UserId = userId,
                Page = page,
                PageSize = pagesize
            });

            var count = await _mediator.Send(new CountAsyncUsersQuery { UserId = userId });
            var totalPages = ((double)count / (double)pagesize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var mappedResult = _mapper.Map<IEnumerable<ReviewViewModel>>(result);
            return Ok(new PagedResponse<IEnumerable<ReviewViewModel>>(mappedResult, page, count, roundedTotalPages, pagesize));
        }


        [HttpPost]
        [Route("createreview")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewToCreateViewModel review)
        {
            var reviewToCreate = new Review
            {
                Content = review.Content,
                Rating = review.Rating,
                MovieId = review.MovieId,
                UserId = review.UserId
            };

            var result = await _mediator.Send(new CreateReviewCommand
            {
                Review = reviewToCreate
            });

            var mappedResult = _mapper.Map<ReviewViewModel>(result);
            return Ok(mappedResult);
        }
        [HttpDelete]
        [Route("deletereview/{reviewId}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid reviewId)
        {
            await _mediator.Send(new DeleteReviewCommand
            {
                Id = reviewId
            });

            return Ok("200");
        }
    }
}
