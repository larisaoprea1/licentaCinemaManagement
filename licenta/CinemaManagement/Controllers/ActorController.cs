using AutoMapper;
using CinemaManagement.Application.Actors.Commands.AddActorToMovie;
using CinemaManagement.Application.Actors.Commands.CreateActor;
using CinemaManagement.Application.Actors.Commands.DeleteActor;
using CinemaManagement.Application.Actors.Commands.EditActor;
using CinemaManagement.Application.Actors.Queries.GetActorsById;
using CinemaManagement.Application.Actors.Queries.GetAllActors;
using CinemaManagement.Application.Genres.Queries.GetAllGenres;
using CinemaManagement.Application.Genres.Queries.GetGenreById;
using CinemaManagement.Application.Movies.Commands.DeleteMovie;
using CinemaManagement.Application.Movies.Commands.UpdateMovie;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.ActorViewModels;
using CinemaManagement.ViewModels.GenreViewModels;
using CinemaManagement.ViewModels.MovieViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/actor")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ActorController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("actors")]
        public async Task<IActionResult> GetActors()
        {
            var actors = await _mediator.Send(new GetAllActorsQuery());
            var result = _mapper.Map<IEnumerable<ActorViewModel>>(actors);
            return Ok(result);
        }
        [HttpGet]
        [Route("getactor/{actorId}")]
        public async Task<IActionResult> GetActor([FromRoute] Guid actorId)
        {
            var result = await _mediator.Send(new GetActorByIdQuery
            {
                Id = actorId
            });
            return Ok(result);
        }
        [HttpPost]
        [Route("createactor")]
        public async Task<IActionResult> CreateActor([FromBody] ActorForCreateViewModel actor)
        {
            var actorToCreate = new Actor
            {
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Information = actor.Information,
                Nationality = actor.Nationality,
                BirthDay = actor.BirthDay,
                PictureSrc = actor.PictureSrc
            };
            var result = await _mediator.Send(new CreateActorCommand
            {
                Actor = actorToCreate,
            });
            var resultMapped = _mapper.Map<ActorViewModel>(result);
            return Ok(resultMapped);
        }
        [HttpPost]
        [Route("addactor/movie/{movieId}/actor/{actorId}")]
        public async Task<IActionResult> AddActorToMovie([FromRoute] Guid movieId, Guid actorId)
        {
            var actorToAdd = await _mediator.Send(new AddActorToMovieCommand
            {
                MovieId = movieId,
                ActorId = actorId
            });
            var result = _mapper.Map<ActorViewModel>(actorToAdd);
            return Ok(result);
        }
        [HttpPut]
        [Route("editactor/{actorId}")]
        public async Task<ActionResult<ActorViewModel>> EditActor([FromRoute] Guid actorId, ActorForUpdateViewModel actor)
        {
            var result = await _mediator.Send(new EditActorCommand
            {
                Id = actorId,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                Nationality = actor.Nationality,
                Information = actor.Information,
                BirthDay = actor.BirthDay,
                PictureSrc = actor.PictureSrc  
                
            });
            if (result == null)
            {
                NotFound("404");
            }
            var mapResult = _mapper.Map<ActorViewModel>(result);
            return Ok(mapResult);
        }
        [HttpDelete]
        [Route("deleteactor/{actorId}")]
        public async Task<IActionResult> DeleteActor([FromRoute] Guid actorId)
        {
            await _mediator.Send(new DeleteActorCommand
            {
                Id = actorId
            });
            return Ok("200");
        }
    }
}
