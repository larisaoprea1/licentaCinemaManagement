using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Commands.EditCinema
{
    public class EditCinemaCommandHandler : IRequestHandler<EditCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public EditCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(EditCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = new Cinema
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                Zipcode = request.Zipcode,
            };

            await _cinemaRepository.UpdateCinemaAsync(cinema);
            await _cinemaRepository.SaveAsync();
            return cinema;
        }
    }
}
