using CinemaManagement.Domain.Models;
using MediatR;

namespace CinemaManagement.Application.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery :IRequest<Movie>
    {
        public Guid Id { get; set; }
    }
}
