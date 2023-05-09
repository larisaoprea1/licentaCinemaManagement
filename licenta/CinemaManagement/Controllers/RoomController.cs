using AutoMapper;
using CinemaManagement.Application.Rooms.Commands.CreateRoom;
using CinemaManagement.Application.Rooms.Queries.GetAllRoomsWithoutPagination;
using CinemaManagement.Application.Rooms.Queries.GetRoomById;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.RoomViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public RoomController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("roomsnotpaginated")]
        public async Task<IActionResult> GetRoomsWithoutPagination()
        {
            var productions = await _mediator.Send(new GetAllRoomsWithoutPaginationQuery());
            var result = _mapper.Map<IEnumerable<RoomViewModel>>(productions);
            return Ok(result);
        }

        [HttpGet]
        [Route("getroom/{roomId}")]
        public async Task<IActionResult> GetRoom([FromRoute] Guid roomId)
        {
            var result = await _mediator.Send(new GetRoomByIdQuery
            {
                Id = roomId
            });
            var mappedResult = _mapper.Map<RoomViewModel>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("createroom")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomForCreateViewModel room)
        {
            var roomToCreate = new Room
            {
                Name = room.Name,
                CinemaId = room.CinemaId,
            };

            var seats = _mapper.Map<ICollection<Seat>>(room.Seats);
            var result = await _mediator.Send(new CreateRoomCommand
            {
                Room = roomToCreate,
                Seats = seats
            });
            var resultMapped = _mapper.Map<RoomViewModel>(result);
            return Ok(resultMapped);
        }
    }
}
