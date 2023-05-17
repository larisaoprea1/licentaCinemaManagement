using AutoMapper;
using CinemaManagement.Application.Sessions.Commands.CreateSession;
using CinemaManagement.Application.Sessions.Queries.GetSessionById;
using CinemaManagement.Application.Sessions.Queries.GetSessionForMovieByCinema;
using CinemaManagement.Application.Sessions.Queries.GetSessions;
using CinemaManagement.Application.Sessions.Queries.GetSessionsByRoomId;
using CinemaManagement.Application.Sessions.Queries.GetSessionsForMovie;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.SessionViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public SessionController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("sessions")]
        public async Task<IActionResult> GetSessions()
        {
            var sessions = await _mediator.Send(new GetSessionsQuery());
            var result = _mapper.Map<IEnumerable<SessionViewModel>>(sessions);
            return Ok(result);
        }

        [HttpGet]
        [Route("sessions/movieId/{movieId}")]
        public async Task<IActionResult> GetSessionsForMovie([FromRoute] Guid movieId)
        {
            var sessions = await _mediator.Send(new GetSessionsForMovieQuery { MovieId = movieId});
            var result = _mapper.Map<IEnumerable<SessionViewModel>>(sessions);
            return Ok(result);
        }

        [HttpGet]
        [Route("sessions/movieId/{movieId}/cinema/{cinemaId}")]
        public async Task<IActionResult> GetSessionsForMovieByCinema([FromRoute] Guid movieId, [FromRoute] Guid cinemaId)
        {
            var sessions = await _mediator.Send(new GetSessionForMovieByCinemaQuery { MovieId = movieId, CinemaId = cinemaId });
            var result = _mapper.Map<IEnumerable<SessionViewModel>>(sessions);
            return Ok(result);
        }

        [HttpGet]
        [Route("getsession/{sessionId}")]
        public async Task<IActionResult> GetSession([FromRoute] Guid sessionId)
        {
            var result = await _mediator.Send(new GetSessionByIdQuery
            {
                Id = sessionId
            });
            var mappedResult = _mapper.Map<SessionViewModel>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("getsessions/room/{roomId}")]
        public async Task<IActionResult> GetSessionsByRoomId([FromRoute] Guid roomId)
        {
            var result = await _mediator.Send(new GetSessionByRoomIdQuery
            {
                RoomId = roomId
            });
            var mappedResult = _mapper.Map<IEnumerable<SessionViewModel>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("createsession")]
        public async Task<IActionResult> CreateSession([FromBody] SessionForCreateViewModel session)
        {
            var sessionToCreate = new Session
            {
                SessionStart = session.SessionStart,
                SessionEnd = session.SessionEnd,
                RoomId = session.RoomId,
                MovieId = session.MovieId
            };

            var result = await _mediator.Send(new CreateSessionCommand
            {
                Session = sessionToCreate,
            });

            if(result == "overlap")
            {
                return BadRequest("A session already exists in this room at this date and hour");
            }

            return Ok(result);
        }
    }
}
