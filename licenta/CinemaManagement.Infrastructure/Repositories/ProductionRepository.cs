using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public ProductionRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Production>> GetProductionsAsync()
        {
            return await _cinemaManagementContext.Productions.ToListAsync();
        }
        public async Task<Production> GetProductionAsync(Guid productionId)
        {
            return await _cinemaManagementContext.Productions.Where(p => p.Id == productionId).FirstOrDefaultAsync();
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
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
