using AutoMapper;
using CinemaManagement.Application.Actors.Commands.DeleteActor;
using CinemaManagement.Application.Actors.Commands.EditActor;
using CinemaManagement.Application.Genres.Commands.AddGenreToMovie;
using CinemaManagement.Application.Genres.Commands.CreateGenre;
using CinemaManagement.Application.Genres.Commands.DeleteGenre;
using CinemaManagement.Application.Genres.Commands.EditGenre;
using CinemaManagement.Application.Genres.Queries.CountGenres;
using CinemaManagement.Application.Genres.Queries.GetAllGenres;
using CinemaManagement.Application.Genres.Queries.GetAllGenresWithoutPagination;
using CinemaManagement.Application.Genres.Queries.GetGenreById;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ActorViewModels;
using CinemaManagement.ViewModels.GenreViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GenreController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("genres/page/{page}/pagesize/{pageSize}")]
        public async Task<IActionResult> GetGenres(int page, int pageSize)
        {
            var result = await _mediator.Send(new GetAllGenresQuery
            {
                Page = page,
                PageSize = pageSize,
            });

            var count = await _mediator.Send(new CountGenresQuery());
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var genres = _mapper.Map<IEnumerable<GenreViewModel>>(result);
            return Ok(new PagedResponse<IEnumerable<GenreViewModel>>(genres, page, count, roundedTotalPages, pageSize));
        }

        [HttpGet]
        [Route("populategenres")]
        public async Task<IActionResult> GetPopulateGenres()
        {
            var result = await _mediator.Send(new GetAllGenresWithoutPaginationQuery());
            var genres = _mapper.Map<IEnumerable<GenreViewModel>>(result);
            return Ok(genres);
        }

        [HttpGet]
        [Route("getgenre/{genreId}")]
        public async Task<IActionResult> GetGenre([FromRoute] Guid genreId)
        {
            var result = await _mediator.Send(new GetGenreByIdQuery
            {
                Id = genreId
            });
            var genre = _mapper.Map<GenreViewModel>(result);
            return Ok(genre);
        }
        [HttpPost]
        [Route("creategenre")]
        public async Task<IActionResult> CreateGenre([FromBody] GenreForCreateViewModel genre)
        {
            var genreToCreate = new Genre
            {
                GenreName = genre.GenreName
            };
            var result = await _mediator.Send(new CreateGenreCommand
            {
                Genre = genreToCreate,
            });
            var resultMapped = _mapper.Map<GenreViewModel>(result);
            return CreatedAtAction(nameof(GetGenre), new { genreId = genreToCreate.Id }, genreToCreate);
        }
        [HttpPost]
        [Route("addgenre/movie/{movieId}/genre/{genreId}")]
        public async Task<IActionResult> AddGenreToMovie(Guid movieId, Guid genreId)
        {
            var genreToAdd = await _mediator.Send(new AddGenreToMovieCommand
            {
                MovieId = movieId,
                GenreId = genreId
            });
            var result = _mapper.Map<GenreViewModel>(genreToAdd);
            return Ok(result);
        }
        [HttpPut]
        [Route("editgenre/{genreId}")]
        public async Task<ActionResult<GenreViewModel>> EditGenre([FromRoute] Guid genreId, GenreForUpdateViewModel genre)
        {
            var result = await _mediator.Send(new EditGenreCommand
            {
                Id = genreId,
                GenreName = genre.GenreName,

            });
            if (result == null)
            {
                NotFound("404");
            }
            var mapResult = _mapper.Map<GenreViewModel>(result);
            return Ok(mapResult);
        }
        [HttpDelete]
        [Route("deletegenre/{genreId}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] Guid genreId)
        {
            await _mediator.Send(new DeleteGenreCommand
            {
                Id = genreId
            });
            return Ok("200");
        }
    }
}
