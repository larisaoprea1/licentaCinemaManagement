using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Queries.GetAllCinemasWithoutPagination
{
    public class GetAllCinemasWithoutPaginationQueryHandler : IRequestHandler<GetAllCinemasWithoutPaginationQuery, IEnumerable<Cinema>>
    {
        private readonly ICinemaRepository _cinemaRepository;
        public GetAllCinemasWithoutPaginationQueryHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<Cinema>> Handle(GetAllCinemasWithoutPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.GetCinemasWithoutPagination();
        }
    }
}
