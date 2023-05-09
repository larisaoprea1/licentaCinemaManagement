using CinemaManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Interfaces
{
    public interface ICinemaRepository
    {
        Task<int> CountAsync();
        Task<Cinema> CreateCinemaAsync(Cinema cinema);
        void DeleteCinema(Cinema cinema);
        Task<Cinema> GetCinemaAsync(Guid cinemaId);
        Task<IEnumerable<Cinema>> GetCinemasAsync(int? page, int pageSize);
        Task<IEnumerable<Cinema>> GetCinemasWithoutPagination();
        Task SaveAsync();
        Task UpdateCinemaAsync(Cinema cinema);
    }
}
