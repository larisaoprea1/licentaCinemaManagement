using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Queries.CountCinemas
{
    public class CountCinemasQueryHandler : IRequestHandler<CountCinemasQuery, int>
    {
        private readonly ICinemaRepository _cinemaRepository;
        public CountCinemasQueryHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<int> Handle(CountCinemasQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.CountAsync();
        }
    }
}
