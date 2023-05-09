using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Queries.GetAllCinemas
{
    public class GetAllCinemasQueryHandler : IRequestHandler<GetAllCinemasQuery, IEnumerable<Cinema>>
    {
        private readonly ICinemaRepository _cinemaRepository;
        public GetAllCinemasQueryHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<Cinema>> Handle(GetAllCinemasQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.GetCinemasAsync(request.Page, request.PageSize);
        }
    }
}
