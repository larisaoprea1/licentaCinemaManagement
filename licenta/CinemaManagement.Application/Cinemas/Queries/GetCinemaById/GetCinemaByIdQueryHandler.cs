using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Queries.GetCinemaById
{
    public class GetCinemaByIdQueryHandler : IRequestHandler<GetCinemaByIdQuery, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;
        public GetCinemaByIdQueryHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.GetCinemaAsync(request.Id);
        }
    }
}
