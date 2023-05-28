using CinemaManagement.Application.Interfaces;
using CinemaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CinemaManagement.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CinemaManagementContext _cinemaManagementContext;

        public ReviewRepository(CinemaManagementContext cinemaManagementContext)
        {
            _cinemaManagementContext = cinemaManagementContext;
        }

        public async Task<Review> CreateAsync(Review review)
        {
            _cinemaManagementContext.Reviews.Add(review);
            return review;
        }

        public async Task<Review> ReturnByIdAsync(Guid id)
        {
            var reviewToReturn = await _cinemaManagementContext.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User)
                .Where(review => review.Id == id)
                .FirstOrDefaultAsync();

            return reviewToReturn;
        }

        public async Task<IEnumerable<Review>> ReturnAllAsync()
        {
            return await _cinemaManagementContext.Reviews
                .Include(x => x.Movie)
                .Include(x => x.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> ReturnMovieReviews(Movie movie, int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);

            return await _cinemaManagementContext.Reviews
                .Where(id => id.MovieId == movie.Id)
                .Include(x => x.User)
                .Include(x => x.Movie)
                .AsNoTracking()
                .OrderByDescending(date => date.CreateDate)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<IEnumerable<Review>> ReturnUserReviews(Guid userId, int? page, int pageSize)
        {
            int pageNumber = (page ?? 1);

            return await _cinemaManagementContext.Reviews
                .Where(id => id.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.Movie)
                .AsNoTracking()
                .OrderByDescending(date => date.CreateDate)
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync(Movie movie)
        {
            return await _cinemaManagementContext.Reviews.Where(id => id.MovieId == movie.Id).CountAsync();
        }

        public async Task<int> CountAsyncUser(Guid userId)
        {
            return await _cinemaManagementContext.Reviews.Where(id => id.UserId == userId).CountAsync();
        }

        public async Task UpdateAsync(Review review)
        {
            _cinemaManagementContext.Update(review);
        }
        public async Task DeleteAsync(Review review)
        {
            _cinemaManagementContext.Reviews.Remove(review);
        }
        public async Task SaveAsync()
        {
            await _cinemaManagementContext.SaveChangesAsync();
        }
    }
}
