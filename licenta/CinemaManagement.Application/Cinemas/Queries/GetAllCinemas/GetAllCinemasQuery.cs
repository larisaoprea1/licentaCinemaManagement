using CinemaManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Cinemas.Queries.GetAllCinemas
{
    public class GetAllCinemasQuery : IRequest<IEnumerable<Cinema>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
