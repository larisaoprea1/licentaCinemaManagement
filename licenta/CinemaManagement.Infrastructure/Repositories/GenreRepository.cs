using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public GenreRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _cinemaManagementContext.Genres.ToListAsync();
        }
        public async Task<Genre> GetGenreAsync(Guid genreId)
        {
            return await _cinemaManagementContext.Genres.Where(g => g.Id == genreId).FirstOrDefaultAsync();
        }
        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            _cinemaManagementContext.Genres.Add(genre);
            return genre;
        }
        public async Task UpdateGenreAsync(Genre genre)
        {
            _cinemaManagementContext.Genres.Update(genre);
        }
        public void DeleteGenre(Genre genre)
        {
            _cinemaManagementContext.Genres.Remove(genre);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
