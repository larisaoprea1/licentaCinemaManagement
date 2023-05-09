
using CinemaManagement.Application.Interfaces;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Commands.DeleteCinema
{
    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public DeleteCinemaCommandHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
        public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.GetCinemaAsync(request.Id);
            _cinemaRepository.DeleteCinema(cinema);
            await _cinemaRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
