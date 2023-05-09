using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public CinemaRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }

        public async Task<IEnumerable<Cinema>> GetCinemasAsync(int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);
            return await _cinemaManagementContext.Cinemas.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<Cinema>> GetCinemasWithoutPagination()
        {
            return await _cinemaManagementContext.Cinemas.ToListAsync();
        }
        public async Task<Cinema> GetCinemaAsync(Guid cinemaId)
        {
            return await _cinemaManagementContext.Cinemas.Include(r => r.Rooms).Where(c => c.Id == cinemaId).FirstOrDefaultAsync();
        }
        public async Task<Cinema> CreateCinemaAsync(Cinema cinema)
        {
            _cinemaManagementContext.Cinemas.Add(cinema);
            return cinema;
        }
        public async Task UpdateCinemaAsync(Cinema cinema)
        {
            _cinemaManagementContext.Cinemas.Update(cinema);
        }
        public void DeleteCinema(Cinema cinema)
        {
            _cinemaManagementContext.Cinemas.Remove(cinema);
        }
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Cinemas.CountAsync();
        }

        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
