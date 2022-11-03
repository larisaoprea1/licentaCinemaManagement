using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.AddProductionToMovie
{
    public class AddProductionToMovieCommandHandler : IRequestHandler<AddProductionToMovieCommand, Production>
    {
        private readonly IProductionRepository _productionRepository;
        private readonly IMovieRepository _movieRepository;
        public AddProductionToMovieCommandHandler(IProductionRepository productionRepository, IMovieRepository movieRepository)
        {
            _productionRepository = productionRepository;
            _movieRepository = movieRepository;
        }

        public async Task<Production> Handle(AddProductionToMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieAsync(request.MovieId);
            var production = await _productionRepository.GetProductionAsync(request.ProductionId);
            await _productionRepository.AddProductionToMovieAsync(movie, production);
            await _productionRepository.SaveAsync();
                return production;
        }
    }
}
