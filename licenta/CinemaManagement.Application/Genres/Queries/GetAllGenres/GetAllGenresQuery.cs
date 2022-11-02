using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Genres.Queries.GetAllGenres
{
    public class GetAllGenresQuery :IRequest<IEnumerable<Genre>>
    {
    }
}
