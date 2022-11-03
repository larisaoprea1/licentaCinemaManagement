using CinemaManagement.Domain.Models;

namespace CinemaManagement.Application.Interfaces
{
    public interface IProductionRepository
    {
        Task<IEnumerable<Production>> GetProductionsAsync();
        Task<Production> GetProductionAsync(Guid productionId);
        Task AddProductionToMovieAsync(Movie movie, Production production);
        Task<Production> CreateProductionAsync(Production production);
        Task UpdateProductionAsync(Production production);
        void DeleteProduction(Production production);
        Task SaveAsync();
    }
}
