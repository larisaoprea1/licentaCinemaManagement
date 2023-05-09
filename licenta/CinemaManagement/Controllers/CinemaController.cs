using AutoMapper;
using CinemaManagement.Application.Cinemas.Commands.CreateCinema;
using CinemaManagement.Application.Cinemas.Commands.DeleteCinema;
using CinemaManagement.Application.Cinemas.Commands.EditCinema;
using CinemaManagement.Application.Cinemas.Queries.CountCinemas;
using CinemaManagement.Application.Cinemas.Queries.GetAllCinemas;
using CinemaManagement.Application.Cinemas.Queries.GetAllCinemasWithoutPagination;
using CinemaManagement.Application.Cinemas.Queries.GetCinemaById;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.CinemaViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CinemaController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("cinemas/page/{page}/pagesize/{pageSize}")]
        public async Task<IActionResult> GetCinemas(int page, int pageSize)
        {
            var result = await _mediator.Send(new GetAllCinemasQuery
            {
                Page = page,
                PageSize = pageSize,
            });

            var count = await _mediator.Send(new CountCinemasQuery());
            var totalPages = ((double)count / (double)pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            var cinemas = _mapper.Map<IEnumerable<CinemaViewModel>>(result);
            return Ok(new PagedResponse<IEnumerable<CinemaViewModel>>(cinemas, page, count, roundedTotalPages, pageSize));
        }

        [HttpGet]
        [Route("populatecinemas")]
        public async Task<IActionResult> GetPopulateCinemas()
        {
            var result = await _mediator.Send(new GetAllCinemasWithoutPaginationQuery());
            var cinemas = _mapper.Map<IEnumerable<CinemaViewModel>>(result);
            return Ok(cinemas);
        }

        [HttpGet]
        [Route("getcinema/{cinemaId}")]
        public async Task<IActionResult> GetCinema([FromRoute] Guid cinemaId)
        {
            var result = await _mediator.Send(new GetCinemaByIdQuery
            {
                Id = cinemaId
            });
            var cinema = _mapper.Map<CinemaViewModel>(result);
            return Ok(cinema);
        }

        [HttpPost]
        [Route("createcinema")]
        public async Task<IActionResult> CreateCinema([FromBody] CinemaForCreateViewModel cinema)
        {
            var cinemaToCreate = new Cinema
            {
                Name = cinema.Name,
                Address = cinema.Address,
                City = cinema.City,
                Zipcode = cinema.Zipcode,
                Country = cinema.Country,

            };
            var result = await _mediator.Send(new CreateCinemaCommand
            {
                Cinema = cinemaToCreate,
            });
            var resultMapped = _mapper.Map<CinemaViewModel>(result);
            return CreatedAtAction(nameof(GetCinema), new { cinemaId = cinemaToCreate.Id }, cinemaToCreate);
        }

        [HttpPut]
        [Route("editcinema/{cinemaId}")]
        public async Task<ActionResult<CinemaViewModel>> EditCinema([FromRoute] Guid cinemaId, CinemaForCreateViewModel cinema)
        {
            var result = await _mediator.Send(new EditCinemaCommand
            {
                Id = cinemaId,
                Name = cinema.Name,
                Address = cinema.Address,
                City = cinema.City,
                Zipcode = cinema.Zipcode,
                Country = cinema.Country,

            });
            if (result == null)
            {
                NotFound("404");
            }
            var mapResult = _mapper.Map<CinemaViewModel>(result);
            return Ok(mapResult);
        }

        [HttpDelete]
        [Route("deletecinema/{cinemaId}")]
        public async Task<IActionResult> DeleteCinema([FromRoute] Guid cinemaId)
        {
            await _mediator.Send(new DeleteCinemaCommand
            {
                Id = cinemaId
            });
            return Ok("200");
        }
    }
}

