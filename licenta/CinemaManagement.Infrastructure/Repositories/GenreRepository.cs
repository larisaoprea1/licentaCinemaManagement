﻿using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;
        public GenreRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }
        public async Task<IEnumerable<Genre>> GetGenresAsync(int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);
            return await _cinemaManagementContext.Genres.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<Genre>> GetGenresWithoutPagination()
        {
            return await _cinemaManagementContext.Genres.ToListAsync();
        }
        public async Task<ICollection<Genre>> GetGenresById(List<Guid> ids)
        {
            return await _cinemaManagementContext.Genres.Where(genre => ids.Contains(genre.Id)).ToListAsync();
        }
        public async Task<Genre> GetGenreAsync(Guid genreId)
        {
            return await _cinemaManagementContext.Genres.Include(m => m.Movies).Where(g => g.Id == genreId).FirstOrDefaultAsync();
        }
        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            _cinemaManagementContext.Genres.Add(genre);
            return genre;
        }
        public async Task AddGenreToMovieAsync(Movie movie, Genre genre)
        {
            movie.Genres.Add(genre);
        }
        public async Task UpdateGenreAsync(Genre genre)
        {
            _cinemaManagementContext.Genres.Update(genre);
        }
        public void DeleteGenre(Genre genre)
        {
            _cinemaManagementContext.Genres.Remove(genre);
        }
        public async Task<int> CountAsync()
        {
            return await _cinemaManagementContext.Genres.CountAsync();
        }

        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
