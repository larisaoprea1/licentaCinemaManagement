using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Productions.Commands.AddProductionToMovie
{
    public class AddProductionToMovieCommand: IRequest<Production>
    {
        public Guid MovieId { get; set; }
        public Guid ProductionId { get; set; }
    }
}
