using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Queries.GetGenreById
{
    public class GetGenreByIdQuery :IRequest<Genre>
    {
        public Guid Id { get; set; }
    }
}
