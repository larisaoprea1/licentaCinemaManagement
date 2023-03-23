using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public ProductionRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Production>> GetProductionsAsync(int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);
            return await _cinemaManagementContext.Productions.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<Production>> GetProductionsWithoutPagination()
        {
            return await _cinemaManagementContext.Productions.ToListAsync();
        }
        public async Task<ICollection<Production>> GetProductionsById(List<Guid> ids)
        {
            return await _cinemaManagementContext.Productions.Where(production => ids.Contains(production.Id)).ToListAsync();
        }
        public async Task<Production> GetProductionAsync(Guid productionId)
        {
            return await _cinemaManagementContext.Productions.Include(m => m.Movies).Where(p => p.Id == productionId).FirstOrDefaultAsync();
        }
        public async Task AddProductionToMovieAsync(Movie movie, Production production)
        {
            movie.Productions.Add(production);
        }
        public async Task<Production> CreateProductionAsync(Production production)
        {
            _cinemaManagementContext.Productions.Add(production);
            return production;
        }
        public async Task UpdateProductionAsync(Production production)
        {
            _cinemaManagementContext.Productions.Update(production);
        }
        public void DeleteProduction(Production production)
        {
            _cinemaManagementContext.Productions.Remove(production);
        }
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Productions.CountAsync();
        }

        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
