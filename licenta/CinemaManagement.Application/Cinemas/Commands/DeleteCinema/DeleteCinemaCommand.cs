using MediatR;

namespace CinemaManagement.Application.Cinemas.Commands.DeleteCinema
{
    public class DeleteCinemaCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
