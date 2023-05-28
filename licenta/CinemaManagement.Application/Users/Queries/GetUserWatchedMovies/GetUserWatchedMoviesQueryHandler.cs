using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Users.Queries.GetUserWatchedMovies
{
    public class GetUserWatchedMoviesQueryHandler : IRequestHandler<GetUserWatchedMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserWatchedMoviesQueryHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetUserWatchedMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _userRepository.GetUsersWatchedMovies(request.UserName);
            return movies;
        }
    }
}
