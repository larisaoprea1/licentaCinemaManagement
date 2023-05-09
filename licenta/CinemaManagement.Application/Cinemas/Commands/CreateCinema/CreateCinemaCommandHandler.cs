

using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Commands.CreateCinema
{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CreateCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.CreateCinemaAsync(request.Cinema);
            await _cinemaRepository.SaveAsync();
            return cinema;
        }
    }
}
