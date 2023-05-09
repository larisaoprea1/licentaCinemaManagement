
using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Commands.CreateCinema
{
    public class CreateCinemaCommand : IRequest<Cinema>
    {
        public Cinema Cinema { get; set; }
    }
}
