using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Cinemas.Queries.GetCinemaById
{
    public class GetCinemaByIdQuery : IRequest<Cinema>
    {
        public Guid Id { get; set; }
    }
}
