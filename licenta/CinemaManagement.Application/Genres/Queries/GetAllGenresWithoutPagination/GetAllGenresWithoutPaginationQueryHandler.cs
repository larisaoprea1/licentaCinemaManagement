using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Genres.Queries.GetAllGenresWithoutPagination
{
    public class GetAllGenresWithoutPaginationQueryHandler : IRequestHandler<GetAllGenresWithoutPaginationQuery, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _genreRepository;
        public GetAllGenresWithoutPaginationQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> Handle(GetAllGenresWithoutPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetGenresWithoutPagination();
        }
    }
}
