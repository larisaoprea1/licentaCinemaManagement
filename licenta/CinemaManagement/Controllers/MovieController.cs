using AutoMapper;
using CinemaManagement.Application.Movies.Commands.CreateMovie;
using CinemaManagement.Application.Movies.Commands.DeleteMovie;
using CinemaManagement.Application.Movies.Commands.UpdateMovie;
using CinemaManagement.Application.Movies.Queries.GetAllMovies;
using CinemaManagement.Application.Movies.Queries.GetMovieById;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.MovieViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public MovieController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("movies")]
        public async Task<IActionResult> GetMovies([FromQuery] string? searchMovies)
        {
            var result = await _mediator.Send(new GetAllMoviesQuery
            {
                SearchString = searchMovies
            });
            var movies = _mapper.Map<IEnumerable<MovieViewModel>>(result);
            return Ok(movies);
        }
        [HttpGet]
        [Route("movieId/{movieId}")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid movieId)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery
            {
                Id = movieId
            });
            if (result == null)
            {
                return NotFound();
            }
            var movie = _mapper.Map<MovieViewModel>(result);
            return Ok(movie);
        }
        [HttpPost]
        [Route("addmovie")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieForCreateViewModel movie)
        {
            var movieToCreate = new Movie
            {
                Name = movie.Name,
                Description = movie.Description,
                IsAdult = movie.IsAdult,
                Format = movie.Format,
                Director = movie.Director,
                ImdbLink = movie.ImdbLink,
                TrailerLink = movie.TrailerLink,
                Poster = movie.Poster,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                MovieBudget = movie.MovieBudget,
                Actors = new List<Actor>(),
                Genres = new List<Genre>(),
                Productions = new List<Production>()
            };
            var result = await _mediator.Send(new CreateMovieCommand
            {
                Movie = movieToCreate
            });
            var createdMovieToReturn = _mapper.Map<MovieViewModel>(result);
            return CreatedAtAction(nameof(GetMovie), new { movieId = movieToCreate.Id }, movieToCreate);
            
        }
        [HttpPut]
        [Route("updatemovie/{movieId}")]
        public async Task<ActionResult<MovieViewModel>> UpdateMovie([FromRoute] Guid movieId, MovieForUpdateViewModel movie)
        {
            var result = await _mediator.Send(new UpdateMovieCommand
            {
                Id = movieId,
                Name = movie.Name,
                Description = movie.Description,
                Director = movie.Director,
                Format = movie.Format,
                IsAdult = movie.IsAdult,
                ImdbLink = movie.ImdbLink,
                TrailerLink = movie.TrailerLink,
                Poster = movie.Poster,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                MovieBudget = movie.MovieBudget,
                Genres = new List<Genre>()
            });
            if (result == null)
            {
                NotFound("404");
            }
            var mapResult = _mapper.Map<MovieViewModel>(result);
            return Ok(mapResult);
        }
        [HttpDelete]
        [Route("deletemovie/{movieId}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] Guid movieId)
        {
            await _mediator.Send(new DeleteMovieCommand
            {
                Id = movieId
            });
            return Ok("200");
        }
    }
}
