using AutoMapper;
using CinemaManagement.Application.Actors.Commands.DeleteActor;
using CinemaManagement.Application.Genres.Commands.EditGenre;
using CinemaManagement.Application.Productions.Commands.AddProductionToMovie;
using CinemaManagement.Application.Productions.Commands.CreateProduction;
using CinemaManagement.Application.Productions.Commands.DeleteProduction;
using CinemaManagement.Application.Productions.Commands.EditProduction;
using CinemaManagement.Application.Productions.Queries.GetAllProductions;
using CinemaManagement.Application.Productions.Queries.GetProductionById;
using CinemaManagement.Domain.Models;
using CinemaManagement.ViewModels.GenreViewModels;
using CinemaManagement.ViewModels.ProductionViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/production")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductionController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet]
        [Route("productions")]
        public async Task<IActionResult> GetProductions()
        {
            var productions = await _mediator.Send(new GetAllProductionsQuery());
            var result = _mapper.Map<IEnumerable<ProductionViewModel>>(productions);
            return Ok(result);
        }
        [HttpGet]
        [Route("getproduction/{productionId}")]
        public async Task<IActionResult> GetProduction([FromRoute] Guid productionId)
        {
            var result = await _mediator.Send(new GetProductionByIdQuery
            {
                Id = productionId
            });
            return Ok(result);
        }
        [HttpPost]
        [Route("createproduction")]
        public async Task<IActionResult> CreateProduction([FromBody] ProductionForCreateViewModel production)
        {
            var productionToCreate = new Production
            {
                ProductionName = production.ProductionName,
                Description = production.Description
            };
            var result = await _mediator.Send(new CreateProductionCommand
            {
                Production = productionToCreate,
            });
            var resultMapped = _mapper.Map<ProductionViewModel>(result);
            return Ok(resultMapped);
        }
        [HttpPost]
        [Route("addproduction/movie/{movieId}/production/{productionId}")]
        public async Task<IActionResult> AddProductionToMovie(Guid movieId, Guid productionId)
        {
            var productionToAdd = await _mediator.Send(new AddProductionToMovieCommand
            {
                MovieId = movieId,
                ProductionId = productionId
            });
            var result = _mapper.Map<ProductionViewModel>(productionToAdd);
            return Ok(result);
        }
        [HttpPut]
        [Route("editproduction/{productionId}")]
        public async Task<ActionResult<ProductionViewModel>> EditProduction([FromRoute] Guid productionId, ProductionForUpdateViewModel production)
        {
            var result = await _mediator.Send(new EditProductionCommand
            {
                Id = productionId,
                ProductionName = production.ProductionName,
                Description= production.Description,    

            });
            if (result == null)
            {
                NotFound("404");
            }
            var mapResult = _mapper.Map<ProductionViewModel>(result);
            return Ok(mapResult);
        }
        [HttpDelete]
        [Route("deleteproduction/{productionId}")]
        public async Task<IActionResult> DeleteProduction([FromRoute] Guid productionId)
        {
            await _mediator.Send(new DeleteProductionCommand
            {
                Id = productionId
            });
            return Ok("200");
        }
    }
}
